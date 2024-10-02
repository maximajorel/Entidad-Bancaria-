using System;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class NombreDelPrograma
{

    static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
    static int numeroCuenta = 1;
    class CuentaBancaria {
        public int numeroCuenta;
        private string nombre;
        private string apellido;
        private double saldo ;
        private double saldoInicial;

        // Constructor
        public CuentaBancaria(int numeroCuentaUsuario, string nombreUsuario, string apellidoUsuario, double saldoUsuario, double saldoInicialUsuario) {
            this.numeroCuenta = numeroCuentaUsuario;
            this.nombre = nombreUsuario;
            this.apellido = apellidoUsuario;
            this.saldo = saldoUsuario;
            this.saldoInicial = saldoInicialUsuario;

        }
        // Mostrar informacion
        public void mostrarInformacion()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Apellido y Nombre del cliente: {apellido} {nombre}");
            Console.WriteLine($"Número de cuenta del cliente: {numeroCuenta}");
            if (saldo < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Saldo de la cuenta: ${saldo}");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine($"Saldo de la cuenta: ${saldo}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
            Console.WriteLine();
            Console.WriteLine();
        }

        // Actualizar saldos
            // Realizar Deposito
               public double realizarDeposito(double deposito)
        {
            Console.Clear();
                   
                    Console.WriteLine();

                    bool depositoValido = false;

                    while (!depositoValido) {                        
                        if (deposito > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deposito realizado exitósamente");
                            Console.ResetColor();
                            saldo += deposito;
                            depositoValido = true;
                            Console.ReadKey();
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("El numero ingresado no es válido, por favor ingrese un numero mayor a 0");
                            Console.ResetColor();
                        }
                    }
            return deposito;
        }
            // Extraer dinero
                public void extraerDinero(double extraccion) {
            Console.Clear();

            bool extraccionValida = false;
            double maximoSaldoNegativo = saldoInicial * 0.10;
            while (!extraccionValida) {

                if (extraccion > (saldo + (saldoInicial * 0.10)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"La operacion que desea realizar no es posible debido a los limites de su cuenta, usted tiene disponible  ${saldo}, aunque, puede extraer como máximo ${saldo + (saldoInicial * 0.10)}");
                    Console.ResetColor();
                    extraccion = validadDecimal("Ingrese la cantidad de dinero que desea extraer: $");
                }
                else { 
                
                    saldo -= extraccion;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Operacion realizada con exito");
                    Console.ResetColor();
                    Console.ReadKey();
                    extraccionValida = true;
                }
            }
        }
            // Actualizar limite de cuenta
                    public void actualizarLimite(double nuevoLimite) {

            this.saldoInicial = (nuevoLimite / 0.10);
            Console.WriteLine(saldoInicial);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operacion realizada con exito");
            Console.ResetColor();
            Console.ReadKey();

                    }

        
    }

    // Validaciones

    static int validadEntero(string mensaje) {

        int resultado = 0;
        bool numeroValido = false;

        while (!numeroValido) {
            Console.Write(mensaje);
            string dato = Console.ReadLine()!;

            if (int.TryParse(dato, out resultado)){ 
            
                numeroValido =true;

            }
            else
            {

                Console.WriteLine("Por favor, ingrese un número entero valido");
            }
        
        }
        
        return resultado;


    }

    static double validadDecimal(string mensaje)
    {

        double resultado = 0;
        bool numeroValido = false;

        while (!numeroValido)
        {
            Console.Write(mensaje);
            string dato = Console.ReadLine()!;

            if (double.TryParse(dato, out resultado))
            {

                numeroValido = true;

            }
            else
            {

                Console.WriteLine("Por favor, ingrese un número decimal valido");
            }

        }

        return resultado;


    }

    static string validarTexto(string mensaje, string error) {

        string resultado = "";
        bool textoValido = false;
        

        while (!textoValido) { 
            
            Console.Write(mensaje);

            string dato = Console.ReadLine()!;

            if (string.IsNullOrEmpty(dato) || string.IsNullOrWhiteSpace(dato))
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ResetColor();
            }
            else {
                resultado = dato;
            textoValido=true;
            }
        }
        return resultado;
    }


    // Menu actualizarSaldos
    // 
    static void menuActualizarSaldo() {

        Console.Clear();
        int cuentaBancaria = validadEntero("Ingrese el número de la cuenta bancaria: ");
        Console.Clear();
        bool cuentaEncontrada = false;


        while (!cuentaEncontrada) {
            Console.Clear();
            foreach (CuentaBancaria cuenta in cuentas)
            {
                if (cuenta.numeroCuenta == cuentaBancaria) {
                    cuenta.mostrarInformacion();
                }


            }

            Console.WriteLine("Desea actualizar el saldo de esta cuenta?");
            int continuar = validadEntero("1. Si / 2. No: ");

            if (continuar == 1)
            {
                cuentaEncontrada = true;
            }
            else
            {
                Console.Clear();
                cuentaBancaria = validadEntero("Ingrese el número de la cuenta bancaria: ");
            }
        }

        Console.Clear();
        Console.WriteLine("1. Realizar deposito");
        Console.WriteLine("2. Realizar extracción");
        Console.WriteLine();
        Console.WriteLine();

        int opcionMenu = validadEntero("Seleccione una opción: ");
        bool opcionValida = false;

        while (!opcionValida)
        {
            switch (opcionMenu)
            {
                case 1:
                    foreach (CuentaBancaria cuenta in cuentas) {
                        if (cuenta.numeroCuenta == cuentaBancaria) {
                            Console.Clear();
                            double deposito = validadDecimal("Ingrese cuanto dinero desea depositar: $");
                            cuenta.realizarDeposito(deposito);
                        }
                    }
                    opcionValida = true;
                break;
                case 2:
                    foreach (CuentaBancaria cuenta in cuentas)
                    {
                        if (cuenta.numeroCuenta == cuentaBancaria)
                        {
                            Console.Clear();
                            double extracción = validadDecimal("Ingrese cuanto dinero desea extraer: $");
                            cuenta.extraerDinero(extracción);
                        }
                    }
                    opcionValida = true;
                    break ;
                default:
                    Console.WriteLine("Opcion ingresada invalida, por favor intente de nuevo.");
                    break ;
            }
        }




    }
    static void realizarDepositoCuenta(int numeroCuenta) {
        Console.Clear();
        foreach (CuentaBancaria cuenta in cuentas) {
            if (cuenta.numeroCuenta == numeroCuenta) {
                bool saldoValido = false;

                while (!saldoValido) {

                    double agregarSaldo = validadDecimal("Ingrese cuanto dinero desea depositar: $");
                    if (agregarSaldo < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor ingrese un número mayor a 0");
                    }
                    else {
                        cuenta.realizarDeposito(agregarSaldo);
                        saldoValido = true;
                    }
                }
                

            }
        }
    }
    static void realizarExtraccionCuenta(int numeroCuenta)
    {
        Console.Clear();
        foreach (CuentaBancaria cuenta in cuentas)
        {
            if (cuenta.numeroCuenta == numeroCuenta)
            {
                bool saldoValido = false;

                while (!saldoValido)
                {

                    double extraccion = validadDecimal("Ingrese cuanto dinero desea extraer: $");
                    if (extraccion < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Por favor ingrese un número mayor a 0");
                    }
                    else
                    {
                        cuenta.extraerDinero(extraccion);
                        saldoValido = true;
                    }
                }


            }
        }
    }

    // Agregar cuenta
    static void agregarCuenta() {

        Console.Clear();

        string nombre = validarTexto("Ingrese el nombre del cliente: ", "Por favor, ingrese un nombre válido");
        string apellido = validarTexto("Ingrese el apellido del cliente: ", "Por favor, ingrese un apellido válido");

        bool saldoValido = false;
        double saldo = 0;
        while (!saldoValido) 
        {

            saldo = validadDecimal("Ingrese el valor del primer depósito: $");

            if (saldo > 0)
            {
                saldoValido = true;
            }
            else { 
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine($"Para poder continuar, debe ingresar dinero a la cuenta");
                Console.ResetColor();
                 }

        }

        CuentaBancaria cuenta = new CuentaBancaria(numeroCuenta, nombre, apellido, saldo, saldo);
        cuentas.Add(cuenta);
        numeroCuenta++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cuenta Agregada exitosamente");
        Console.ReadKey();
    }
    // Mostrar cuentas
    static void mostrarCuentas() {
        Console.Clear();
        if (cuentas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No existen cuentas cargadas en el sistema");
            Console.ResetColor();
            Console.ReadKey();
        }
        else {
            foreach (CuentaBancaria cuenta in cuentas) {

                cuenta.mostrarInformacion();
                
            }
        }
        Console.ReadKey();
    }
    // Actualizar Limite de una cuenta
    static void actualizarLimiteDeCuenta() {
        Console.Clear();
        bool cuentaEncontrada = false;

        while (!cuentaEncontrada) {
            int numeroCuenta = validadEntero("Ingrese el N° de cuenta: ");

            foreach (CuentaBancaria cuenta in cuentas) {

                if (cuenta.numeroCuenta == numeroCuenta)
                {
                    Console.Clear();
                    cuentaEncontrada = true;
                    Console.WriteLine();
                    Console.WriteLine("Se actualizará el limite de la siguiente cuenta: ");
                    cuenta.mostrarInformacion();
                    Console.ReadKey();

                    double nuevoLimite = validadDecimal("Ingrese el nuevo máximo de extracción: $ ");

                    cuenta.actualizarLimite(nuevoLimite);

                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No existe ninguna cuenta asociada al numero ingresado.");
                    Console.ReadKey();
                }

            
            }

        }

    }


    static void Main(string[] args)
    {
        bool salirMenu = false;
        while (!salirMenu)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  J@@@@J    ?@@@@7    Y@@@@?  ");
            Console.WriteLine("  ^@@@@#^   ?@@@@7   ^&@@@&^  ");
            Console.WriteLine("   ?@@@@&J: ?@@@@! :J&@@@@7   ");
            Console.WriteLine("    7&@@@@&GG@@@@GG&@@@@#!    ");
            Console.WriteLine("     .JB@@@@@@@@@@@@@@B?.     ");
            Console.WriteLine("  :^^^:^75#@@@@@@@@B57^:^^^:  ");
            Console.WriteLine("  5@@@@@&&&@@@@@@@@&&&@@@@@5   Banco UTN");
            Console.WriteLine("  5@@@@@&&&@@@@@@@@&&&@@@@@5   Sucursal FRT");
            Console.WriteLine("  :^^::^75#@@@@@@@@B57^::^^:  ");
            Console.WriteLine("     .?B@@@@@@@@@@@@@@B?.     ");
            Console.WriteLine("    7&@@@@&GG@@@@GG&@@@@#!    ");
            Console.WriteLine("   ?@@@@&J: ?@@@@! :J&@@@@7   ");
            Console.WriteLine("  ^@@@@#^   ?@@@@7   ^&@@@&^  ");
            Console.WriteLine("  J@@@@J    ?@@@@7    Y@@@@?  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("1. Información de cuentas bancarias");
            Console.WriteLine("2. Agregar nuevo cliente");
            Console.WriteLine("3. Actualizar saldos en la cuenta de un cliente");
            Console.WriteLine("4. Actualizar límite de extracción de una cuenta bancaria");
            Console.WriteLine("5. Salir del programa");
            Console.WriteLine();
            int opcionUsuario = validadEntero("Para continuar, elija una opción: ");

            switch (opcionUsuario)
            {

                case 1:

                    mostrarCuentas();

                    break;
                case 2:
                    
                    agregarCuenta();
                    break;
                case 3:

                    menuActualizarSaldo();
                    break;
                case 4:
                    actualizarLimiteDeCuenta();
                    break;
                case 5:
                    salirMenu = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opcion incorrecta, intente nuevamente.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;

            }


        }

    }
}