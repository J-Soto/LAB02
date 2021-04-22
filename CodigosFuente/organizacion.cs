using System;
using interfaces.consulta;
/*
 Nombre : John Alexander Soto Tagle
 Codigo: 20161312
 Fecha: 22/04/2021
*/
namespace organizacion {
	namespace rrhh{
		public abstract class Persona: IConsulta
	    {
	        #region Propiedades
	        private int _id;
	        private string _nombre;
	        private string _apellido;
	        private string _dni;
	        #endregion

	        #region Constructor
	        public Persona(int id,string nom, string ap, string dni)
	        {
	            Id = id;
	            Nombre = nom;
	            Apellido = ap;
	            Dni = dni;
	        }
	        #endregion

	        #region Getters y Setters
	        public string Dni
	        {
	            get { return _dni; }
	            set { _dni = value; }
	        }
	        public string Apellido
	        {
	            get { return _apellido; }
	            set { _apellido = value; }
	        }
	        public string Nombre
	        {
	            get { return _nombre; }
	            set { _nombre = value; }
	        }
	        public int Id
	        {
	            get { return _id; }
	            set { _id = value; }
	        }
	        #endregion

	        #region Metodos
	        public abstract string consultarDatos();
	        #endregion

    	}
		namespace empleados{
			public class  Mesero: Persona
		    {
		        #region Propiedades
		        private double _sueldo;
		        #endregion

		        #region Constructor
		        public Mesero(int id, string nom, string ap, string dni,double sueldo):base(id, nom, ap, dni)
		        { 
		            Sueldo = sueldo;
		        }
		        #endregion

		        #region Getters y Setters
		        public double Sueldo
		        {
		            get { return _sueldo; }
		            set { _sueldo = value; }
		        }
		        #endregion

		        #region Metodos
		        public override string consultarDatos()
		        {
		            return "Mesero: "+Dni+" - "+Nombre+" "+Apellido;
		        }
		        #endregion

		    }
		}

		namespace consumidores{
			public enum Categoria
		    {
		        VIP,
		        Platinum,
		        Black
		    }

		    public class  Cliente: Persona
		    {
		        #region Propiedades
		        private Categoria _tipo;
		        #endregion

		        #region Constructor
		        public Cliente(int id, string nom, string ap, string dni, Categoria tipo): base(id, nom, ap, dni)
		        {
		            Tipo = tipo;
		        }
		        #endregion

		        #region Getters y Setters
		        public Categoria Tipo
		        {
		            get { return _tipo; }
		            set { _tipo = value; }
		        }
		        #endregion

		        #region Metodos
		        public override string consultarDatos()
		        {
		            return "Cliente: "+Dni+" -"+ Nombre+" "+Apellido+" -"+Tipo;
		        }
		        #endregion

		    }
		}
	}
}