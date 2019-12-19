using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
/*   Developer: "Aaron Staight"
 *        Spec: This client was desinged and created to share strings via a network/browser
 *              It uses a http listener and receiver to interact with the browser correctly
 *3-rd parties: "NULL"
 */
namespace WebClient
{
    internal class Program
    {
        static string httpInput = "DEFaULT";
        private static void Main(string[] args)
        {
            Console.ForegroundColor=ConsoleColor.White;
            string input;
            string inputCheck;
            string quit = "";
            
            Outputs outputs = new Outputs();

            var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            do {
                do
                {
                    Console.Clear();
                    Console.Write("A simple '");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("webServer");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("' Would you like to send a message?\n");
                    outputs.OutputYesOrNo();
                    input = Console.ReadLine().ToUpper();
                    Console.ForegroundColor = ConsoleColor.White;

                    
                    inputCheck = outputs.Valid_Input_YesNo(input);

                } while (inputCheck == "NO");

                if (input == "YES")
                {
                    do {
                        
                        
                            outputs.OutputBorder1();
                            Console.Write("please type in the string you would like to send?\n\n" +
                                "You can now directly type in HTML code to mapipulate the browser\n\n" +
                                "you can add images and many more things");
                            outputs.OutputBorder2();
                            Console.Write("     String:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            input = Console.ReadLine().ToUpper();
                            Console.ForegroundColor = ConsoleColor.White;
                            
                            httpInput = input;
                        

                        do
                        {
                            Console.Clear();
                            ws.Run();
                            Thread.Sleep(1000);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nGo and check this '");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("http://localhost:8080/test/");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("' link for your output!");
                            outputs.OutputBorder2();
                            Console.WriteLine("\n\nWould you like to input another  string message?\n1=quit\n2=yes");
                            outputs.OutputBorder2();
                            outputs.OutputInput1();
                            Console.ForegroundColor = ConsoleColor.Green;
                            input = Console.ReadLine().ToUpper();
                            Console.ForegroundColor = ConsoleColor.White;
                            inputCheck = outputs.Valid_InputNum0_2(input);
                        } while (inputCheck == "NO");
                    }while (input == "2");
                    input = null;
                }
            } while (quit=="NO");
            if (input == "NO")
            {
                ws.Run();
            }
            Console.WriteLine("\nprogram will quit after you press 'ENTER'");
            Console.ReadLine();
            ws.Stop();
        }







        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><div>{0}<br><br><br>{1}</div></HTML>", "<HTML><BODY><br>hello</BODY></HTML>",httpInput, DateTime.Now);
        }
        
    }
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        public WebServer(IReadOnlyCollection<string> prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");
            }

            // URI prefixes are required eg: "http://localhost:8080/test/"
            if (prefixes == null || prefixes.Count == 0)
            {
                throw new ArgumentException("URI prefixes are required");
            }

            if (method == null)
            {
                throw new ArgumentException("responder method required");
            }

            foreach (var s in prefixes)
            {
                _listener.Prefixes.Add(s);
            }

            _responderMethod = method;
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
           : this(prefixes, method)
        {
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWebserver currently running...\n");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(c =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                if (ctx == null)
                                {
                                    return;
                                }

                                var rstr = _responderMethod(ctx.Request);
                                var buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            {
                                // ignored
                            }
                            finally
                            {
                                // always close the stream
                                if (ctx != null)
                                {
                                    ctx.Response.OutputStream.Close();
                                }
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            });
        }

        public void Stop()
        {
            Console.Write("Coded By 'Aaron Staight'\n;)");
            Thread.Sleep(3000);
            Console.Clear();
            Console.Write("\n\n\n        Goodbye thanks for using my client!!!");
            Thread.Sleep(2250);
            _listener.Stop();
            _listener.Close();
        }
    }

  
}