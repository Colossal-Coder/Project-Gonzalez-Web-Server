using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace WebClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string input;
            string inputCheck;
            Outputs outputs = new Outputs();

            var ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            do {
                do
                {
                    Console.Clear();
                    Console.WriteLine("A simple webserver. Would you like to send a message?");
                    outputs.OutputYesOrNo();
                    input = Console.ReadLine().ToUpper();

                    ws.Run();
                    inputCheck = outputs.Valid_Input_YesNo(input);

                } while (inputCheck == "NO");

                if (input == "YES")
                {
                    do
                    {
                        Console.WriteLine("please type in the string you would like to send?, " +
                            "\nplease use underscores instead of spaces until i solve this glitch!");
                        input = Console.ReadLine();
                        inputCheck = outputs.Valid_NameInput(input);
                    }
                    while (inputCheck == "NO");

                }
            } while ();
            Console.ReadLine();
            ws.Stop();
        }
        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }
        public static string SendCustomResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
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
            _listener.Stop();
            _listener.Close();
        }
    }

  
}