using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DifficilBankDAO.utils
{
    public class ControlMio
    {

        public bool VlBrand(string texto)
        {
            //string patron = @"^[a-zA-Z0-9'ñÑ\sáéíóúÁÉÍÓÚ&äëïöü-]+$";
            string patron = @"^(?! )(?!.* $)[a-zA-Z0-9'ñÑ\sáéíóúÁÉÍÓÚ&äëïöüÄËÏÖÜ-]+$";

            Regex regex = new Regex(patron);
            return regex.IsMatch(texto);
        }



        public bool IsOnlyLetters(string input)
        {
            /*string pattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(input, pattern);*/
            string patron = @"^[\p{L}\sñÑáéíóúÁÉÍÓÚ]+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(input);
        }


        void validaCarnetIdentidad(string carnet)
        {


        }
        public bool ValidarCorreoDominio(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                string dominio = addr.Host.ToLower();

                // Expresión regular para verificar el formato del dominio
                string patron = @"^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                return Regex.IsMatch(dominio, patron);
            }
            catch
            {
                return false;
            }
        }


        
        

        public bool ValidarCorreoInstitucional(string correo)
        {
            try
            {
                // Extraer el dominio del correo electrónico
                string dominio = correo.Split('@')[1];



                // Validar la existencia del dominio
                if (!ValidarDominio(dominio))
                {
                    return false;
                }



                // Intentar enviar un correo al dominio
                using (var client = new SmtpClient())
                {
                    client.Timeout = 5000; // Establecer un tiempo de espera para la operación de envío
                    client.Host = dominio; // Utilizar el dominio como host del servidor SMTP

                    // Enviar un correo de prueba
                    var testMessage = new MailMessage("validacion@miapp.com", correo, "Validación de correo", "Este es un correo de prueba.");
                    client.Send(testMessage);
                }



                return true; // Si no se produce ninguna excepción, el correo es válido
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            // Verificación sintáctica básica del correo electrónico
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                return false;
            }

            // Extraer el dominio del correo electrónico
            string domain = email.Split('@')[1];

            // Verificar la existencia del dominio mediante consulta DNS
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(domain);
            }
            catch (Exception)
            {
                return false;
            }

            // Verificar si el dominio está en la lista de dominios institucionales conocidos
            if (IsInstitutionalDomain(domain))
            {
                return true;
            }

            // Verificar correos de estudiantes basado en patrones específicos
            if (IsStudentEmail(email))
            {
                return true;
            }

            return false;
        }

        private static bool IsInstitutionalDomain(string domain)
        {
            // Lista de dominios institucionales conocidos
            string[] institutionalDomains = { "example.edu", "example.ac.uk", "example.edu.au", "est.univalle.edu" };

            // Verificar si el dominio está en la lista de dominios institucionales
            return Array.Exists(institutionalDomains, d => d.Equals(domain, StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsStudentEmail(string email)
        {
            // Patrón para correos electrónicos de estudiantes basado en un formato específico
            string studentEmailPattern = @"^\w+\d+@(student\.)?example\.edu$";

            // Verificar si el correo electrónico sigue el patrón de correo de estudiante
            return Regex.IsMatch(email, studentEmailPattern, RegexOptions.IgnoreCase);
        }



        private bool ValidarDominio(string dominio)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(dominio);
                // Si no se produce ninguna excepción, el dominio existe
                return true;
            }
            catch (SocketException ex)
            {
                // Si se produce una excepción, el dominio no existe o no se puede resolver
                if (ex.SocketErrorCode == SocketError.HostNotFound || ex.SocketErrorCode == SocketError.NoData)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        
        public bool ValidarDominio2(string dominio)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(dominio);
                // Si no se produce ninguna excepción, el dominio existe
                return true;
            }
            catch (SocketException ex)
            {
                // Si se produce una excepción, el dominio no existe o no se puede resolver
                if (ex.SocketErrorCode == SocketError.HostNotFound || ex.SocketErrorCode == SocketError.NoData)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        

         public bool validaNumeroPositivo(string output)
        {
            string pattern = @"^[0-9]*\.?[0-9]+$";
            Regex rex = new Regex(pattern);
            if (!rex.IsMatch(output))
            {
                return false;
            }
            return true;
        }
        public bool validaNumeroPositivoMayor0(string output)
        {
            string pattern = @"^[1-9][0-9]*\.?[0-9]*$";
            Regex rex = new Regex(pattern);
            if (!rex.IsMatch(output))
            {
                return false;
            }
            return true;
        }



        public bool validatePhone2(string output)
        {
            string pattern = @"^[0-9]{7,12}$";
            Regex rex = new Regex(pattern);
            if (!rex.IsMatch(output))
            {
                return false;
            }
            return true;
        }

    public bool ValidateInput(string input)
        {
            // Patrón para permitir solo letras y espacios
            string pattern = @"^[a-zA-Z\s]+$";

            // Creamos una expresión regular con el patrón
            Regex regex = new Regex(pattern);

            // Validamos el texto ingresado
            bool isValid = regex.IsMatch(input);

            return isValid;
        }
        public bool ValidarImporte(string importe)
        {
            // Expresión regular para validar un importe en formato decimal con hasta dos decimales
            string pattern = @"^\d+(\.\d{1,2})?$";
            Regex regex = new Regex(pattern);



            // Verificar si el valor ingresado coincide con el patrón de la expresión regular
            if (!regex.IsMatch(importe))
            {
                // Mostrar un mensaje de error

                return false;
            }

            return true;
        }
        public bool Validatephone(string output)
        {
            string pattern = @"^\+\d{1,3} \d{7,12}$";
            Regex rex = new Regex(pattern);
            if (!rex.IsMatch(output))
            {
                return false;
            }
            return true;
        }

        public bool ValidarNumeroCi(string numero)
        {
            string patronDigitos = @"^\d{7}(-A)?$"; // Busca exactamente 7 dígitos
            Regex regexDigitos = new Regex(patronDigitos);
            bool tiene7Digitos = regexDigitos.IsMatch(numero);

            return tiene7Digitos;
        }

        public bool ValidarNumeroCi2(string numero)
        {
            string patronDigitos = @"^\d{7,8}(\-[a-zA-Z])?$"; // Busca exactamente de 7 a 8 numeros y al final opcinal -Letra
            Regex regexDigitos = new Regex(patronDigitos);
            bool tiene7Digitos = regexDigitos.IsMatch(numero);

            return tiene7Digitos;
        }

        public bool ValidarNumeroCi3(string numero)
        {
            string patronDigitos = @"^[a-zA-Z]?\-?\d{7,8}(\-[a-zA-Z])?$"; // Busca exactamente de 7 a 8 numeros y al final opcinal -Letra
            Regex regexDigitos = new Regex(patronDigitos);
            bool tiene7Digitos = regexDigitos.IsMatch(numero);

            return tiene7Digitos;
        }

        public bool ValidarNumeroCi4(string numero)
        {
            string patronDigitos = @"^(?:[a-zA-Z]\-?\d{7,8}(\-[a-zA-Z])?|[a-zA-Z])$"; // Busca exactamente de 7 a 8 numeros y al final opcinal -Letra
            Regex regexDigitos = new Regex(patronDigitos);
            bool tiene7Digitos = regexDigitos.IsMatch(numero);

            return tiene7Digitos;
        }

        //^\d{5,10}(\\s|[-])\d{1}[A-Z]{1})$")

        public bool ValidarNumeroCi7(string numero)
        {
            //string patronDigitos = @"^?:E-)?[1-9]\d{5,7}(?:-\d[A-Z])?$"; // Busca exactamente de 7 a 8 numeros y al final opcinal -Letra
            //Regex regexDigitos = new Regex(patronDigitos);
            //bool tiene7Digitos = regexDigitos.IsMatch(numero);



            return Regex.IsMatch(numero, @"^(?:E-)?[1-9]\d{5,7}(?:-\d[A-Z])?$");
        }






        public bool ValidarTextoConÑSinEspacios(string texto)
        {
            // Patrón de expresión regular para validar texto que solo contiene letras (incluyendo la letra "Ñ") y espacios
            //string patron = @"^[a-zA-ZñÑ\s]+$";

            //string patron = @"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$";   primera

            //string patron = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ]+(?:[-]?[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ])*$";

            //string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚñÑ]+)*$";



            // string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9]+)*$";


            string patron = @"^[A-Za-záéíóúÁÉÍÓÚñÑ\s\W]+$";
            return Regex.IsMatch(texto, patron);
        }


        public bool validarDireccionConNumeros(string texto)
        {
            // Patrón de expresión regular para validar texto que solo contiene letras (incluyendo la letra "Ñ") y espacios
            //string patron = @"^[a-zA-ZñÑ\s]+$";

            //string patron = @"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$";   primera

            //string patron = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ]+(?:[-]?[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ])*$";

            //string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚñÑ]+)*$";



            // string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9]+)*$";


            string patron = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 .]*$";
            return Regex.IsMatch(texto, patron);
        }






       


        public bool ValidarDireccion(string texto)
        {



            string patron = @"^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ0-9]*$";
            return Regex.IsMatch(texto, patron);
        }

        public bool ValidarCi(string ci)
        {
            // Patrón de expresión regular para validar el formato del CI: hasta 12 números, un guion y una letra, sin espacios

            //string patron = @" ^\d{1,12}-[a-zA-Z]$";


            string patron = @"^\d{7,8}$";

            return Regex.IsMatch(ci, patron);
        }


        public bool validaEspaciosConPunto(string cadena)
        {
            //string patron = @"^(?!\s)(?!.*\s$)(?!.*\s\s)[\w.]+$";

            string patron = @"^(?!\s)(?!.*\s$)(?!.*\s\s)[^.].*[^.\s]$";
            return Regex.IsMatch(cadena, patron);
        }

        public bool validaPeso(string peso)
        {
            string patron = @"^(?:\d{1,2}|1\d{2}|200)$";
            return Regex.IsMatch(peso, patron);
        }


        public bool compruebaArroba(string email)
        {
            string patron = @"@";
            return Regex.IsMatch(email, patron);
        }
        public bool validarCorreo(string email)
        {

            if (compruebaArroba(email) == true)
            {
                string[] subs = email.Split('@');


                string string1 = subs[0];
                string string2 = subs[1];

                string despuesDelArroba = string2.Substring(0);


                //if (despuesDelArroba == "hotmail.com" || despuesDelArroba == "gmail.com" || despuesDelArroba == "yahoo.com" || despuesDelArroba == "outlook.com") {
                if (despuesDelArroba == "gmail.com")
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        public bool ValidarContraseñaLetrasNumerosYCaracteresRaros(string contraseña)
        {
                                
            //string patron = @"^[a-zA-Z0-9!@#$%^&*()\-=_+[\]{}|;':"",./<>?\\`~]+$";

            string patron = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{8,}$";
            return Regex.IsMatch(contraseña, patron);

        }



        public bool CompruebaFecha(DateTime fecha)
        {
            bool bandera = false;
            DateTime fechaHoy = DateTime.Now;
            //DateTime fecha = DateTime.Parse("2031-12-25");

            int comparacion = fechaHoy.CompareTo(fecha);

            if (comparacion < 0)
            {
                //fecha futurista

            }
            else if (comparacion > 0)
            {

                //fecha buena


                TimeSpan diferencia = fechaHoy.Subtract(fecha);
                bool tiene15Anios = diferencia.TotalDays >= 365 * 25;

                if (tiene15Anios)
                {
                    //Console.WriteLine("Hay una diferencia de 15 años entre las fechas.");
                    bandera = true;
                }
                else
                {
                    //Console.WriteLine("No hay una diferencia de 15 años entre las fechas.");
                    bandera = false;
                }

            }
            else
            {
                //Console.WriteLine("La fecha de hoy);
            }

            return bandera;


        }
        public bool CompruebaFechaAnimal(DateTime fecha)
        {
            bool bandera = false;
            DateTime fechaHoy = DateTime.Now;
            //DateTime fecha = DateTime.Parse("2031-12-25");

            int comparacion = fechaHoy.CompareTo(fecha);

            if (comparacion < 0)
            {
                //fecha futurista

            }
            else if (comparacion > 0)
            {

                //fecha buena
        
                bandera |= true;
            }
            else
            {
                //Console.WriteLine("La fecha de hoy);
            }

            return bandera;


        }

        public bool CompruebaFechaCita(DateTime fecha)
        {
            bool bandera = false;
            DateTime fechaHoy = DateTime.Now;
            //DateTime fecha = DateTime.Parse("2031-12-25");

            int comparacion = fechaHoy.CompareTo(fecha);

            if (comparacion < 0)
            {
                //fecha futurista buea
                bandera = true;

            }
            else if (comparacion > 0)
            {

                //fecha del pasado

                //bandera = true;
            }
            else
            {
                //Console.WriteLine("La fecha de hoy);
            }

            return bandera;


        }



    }
}
