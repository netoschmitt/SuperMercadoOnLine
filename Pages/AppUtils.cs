using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

namespace SuperMercadoNetoOnLine.Pages
{
    public static class AppUtils
    {
        public static async Task ProcessarArquivoDeImagem(int idProduto, IFormFile imagemProduto, IWebHostEnvironment whe)
        {
            //copia a imagem para um stream em memória (carrega em um fluxo de bytes em memoria)
            var ms = new MemoryStream();
            await imagemProduto.CopyToAsync(ms);


            //carrega o stream em memoria para o objeto de processamento de imagem
            ms.Position = 0;                        // posiciono o fluxo em zero(em qual byte)
            var img = await Image.LoadAsync(ms);    // carrego na var img o obj(ms) que esta em memoria, Tipo Image(Lib_SixLabors_ImageSharp)
            JpegEncoder jpegEnc = new JpegEncoder();// conversao da imagem p jpeg
            jpegEnc.Quality = 100;                  // qualidade 100%
            img.SaveAsJpeg(ms, jpegEnc);            // salva a img como jpeg
            ms.Position = 0;                        // posiciona o fluxo de memoria em zero
            img = await Image.LoadAsync(ms);        // copio este fluxo em memoria q esta em jpeg -> p imagem
            ms.Close();                             // fecho fluxo de bites de memoria
            ms.Dispose();                           // Libero esta memoria



            //cria um retangulo de recorte para deixar a imagem quadrada
            var tamanho = img.Size();             // capturo o tamanho da imagem
            Rectangle retanguloCorte;             // crio o retangulo

            if (tamanho.Width > tamanho.Height)
            {
                float x = (tamanho.Width - tamanho.Height) / 2.0F;
                retanguloCorte = new Rectangle((int)x, 0, tamanho.Height, tamanho.Height);
            }
            else
            {
                float y = (tamanho.Height - tamanho.Width) / 2.0F;
                retanguloCorte = new Rectangle(0,(int)y, tamanho.Width, tamanho.Width);
            }

            //recorta a imagem usando o retângulo computado
            img.Mutate(i => i.Crop(retanguloCorte));

            //monta o caminho da imagem (~/img/produto/000000.jpg)"
            var caminhoArquivoImagem = Path.Combine(whe.WebRootPath,
                "img\\produto", idProduto.ToString("D6") + ".jpg");

            //cria um arquivo de imagem sobrescrevendo o existente, caso exista
            await img.SaveAsync(caminhoArquivoImagem);
        }
    }
}
