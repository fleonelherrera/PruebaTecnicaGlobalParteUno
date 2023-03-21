using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PruebaTecnicaConsultoriaGlobal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configuro el driver de Chrome
            IWebDriver driver = new ChromeDriver();

            // Dirijo a la URL
            Console.WriteLine("Me dirijo hacia la página de Consultoría Global");
            driver.Navigate().GoToUrl("https://www.consultoriaglobal.com.ar/cgweb");
            
            // Voy a sección contacto
            Console.WriteLine("Me dirijo hacia la sección de contacto de la página");
            IWebElement contactoLink = driver.FindElement(By.LinkText("Contáctenos"));
            contactoLink.Click();

            // Lleno el formulario
            Console.WriteLine("Completo todo el formulario con una dirección de mail inválida");
            IWebElement inputNombre = driver.FindElement(By.Name("your-name"));
            inputNombre.SendKeys("Franco Herrera");

            IWebElement inputMail = driver.FindElement(By.Name("your-email"));
            inputMail.SendKeys("mailinvalido");

            IWebElement inputAsunto = driver.FindElement(By.Name("your-subject"));
            inputAsunto.SendKeys("Test");

            IWebElement inputMensaje = driver.FindElement(By.Name("your-message"));
            inputMensaje.SendKeys("Hola soy un test");

            // Hago click en enviar
            Console.WriteLine("Envío el formulario");
            IWebElement btnEnviar = driver.FindElement(By.ClassName("wpcf7-submit"));
            btnEnviar.Click();

            // Hago una espera implicita de 5 segundos
            Console.WriteLine("Espero 5 segundos");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            try
            {
                // Detecto el mensaje de error
                IWebElement errorMail = driver.FindElement(By.ClassName("wpcf7-not-valid-tip"));

                // Capturo el error y lo muestro por consola
                string error = errorMail.Text;
                Console.WriteLine("Muestro el mensaje de error por consola: " + error);
            }
            catch (NoSuchElementException)
            {
                throw;
            }
            finally
            {
                driver.Close();
            }



        }
    }
}
