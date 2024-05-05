using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Http ;
using System.Net;
using System.Net.Http.Headers;
namespace MyConsoleApp
{
    class Program
    {
        // lấy nội dung của một trang wed được chỉ định bằng url một cách không đồng bộ . 
        static void ShowHeaders(HttpResponseHeaders headers){
            Console.WriteLine("Cac Header");
                foreach (var header in headers)
                {
                    Console.WriteLine($"{header.Key} : {header.Value}");
                }
            
        }
        public static async Task<string> GetWebContent(string url ){
            using var httpClient = new HttpClient(); // dùng using để đảm bảo http sẽ được giải phóng đúng cách khi không còn dùng nữa // nó gửi các yêu cầu http và nhận các phản hồi từ http ; 
            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);// gửi một yêu cầu đến http get và url
                ShowHeaders(httpResponseMessage.Headers);
                string html = await httpResponseMessage.Content.ReadAsStringAsync(); // đọc nội dung phản hồi 
                 return html ;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return "Loi";
            }
           

        }
        static async Task Main(string[] args)
        {
          // Http request - httpClient ( get / post / )
          var url = " https://xuanthulab.net/networking-su-dung-httpclient-trong-c-tao-cac-truy-van-http.html";
            var html =  await GetWebContent(url);
           
            Console.WriteLine(html) ;
        }
    }
}
