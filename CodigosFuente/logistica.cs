using System;
using interfaces.consulta;
/*
 Nombre : John Alexander Soto Tagle
 Codigo: 20161312
 Fecha: 22/04/2021
*/
 namespace logistica{

 	namespace infraestructura{
 		public class Mesa
	    {
	        #region Propiedades
	        private int _id;       
	        private int _capMax;
	        #endregion

	        #region Constructor
	        public Mesa(int id, int capmax)
	        {
	            Id = id;
	            CapMax = capmax;
	        }
	        #endregion

	        #region Getters y Setters
	        public int Id
	        {
	            get { return _id; }
	            set { _id = value; }
	        }
	        public int CapMax
	        {
	            get { return _capMax; }
	            set { _capMax = value; }
	        }
	        #endregion

	        #region Metodos
	        #endregion

	    }

 	}

 	namespace produtos{
 		 public abstract class ItemVenta:IConsulta
	    {
	        #region Propiedades
	        private int _id;
	        private double _precio;
	        #endregion

	        #region Constructor
	        public ItemVenta(int id, double precio)
	        {
	            Id = id;
	            Precio = precio;
	        }
	        #endregion

	        #region Getters y Setters
	        public int Id
	        {
	            get { return _id; }
	            set { _id = value; }
	        }
	        public double Precio
	        {
	            get { return _precio; }
	            set { _precio = value; }
	        }
	        #endregion

	        #region Metodos
	        public abstract string consultarDatos();
	        #endregion

	    }
 	namespace consumibles{
 		public class Plato:ItemVenta
 		{
			#region Propiedades
		    private string _nombre;
		    #endregion

		    #region Constructor
		    public Plato(int id, string nombre, double precio):base(id, precio)
		    {
		    	Nombre = nombre;
		    }
		    #endregion

		    #region Getters y Setters
		    public string Nombre
		    {
		    	get { return _nombre; }
		    	set { _nombre = value; }
		    }

		    #endregion

		    #region Metodos
		    public override string consultarDatos()
		    {
		    	return Nombre + " - " + "S/. " + Precio;
		    }
		        #endregion

		    }

 		}
 		namespace bebibles{
 			public class Bebida : ItemVenta
		    {
		        #region Propiedades
		        private string _marca;
		        private double _capacidad;
		        private string _unidadMedida;
		        #endregion

		        #region Constructor
		        public Bebida(int id,string marca, double cap, string uni, double precio):base(id, precio)
		        {
		            Marca = marca;
		            Capacidad = cap;
		            UnidadMedida = uni;
		        }
		        #endregion

		        #region Getters y Setters
		        public double Capacidad
		        {
		            get { return _capacidad; }
		            set { _capacidad = value; }
		        }
		        public string Marca
		        {
		            get { return _marca; }
		            set { _marca = value; }
		        }
		        public string UnidadMedida
		        {
		            get { return _unidadMedida; }
		            set { _unidadMedida = value; }
		        }
		        #endregion

		        #region Metodos
		        public override string consultarDatos()
		        {
		            return Marca + " "+Capacidad.ToString("0.#") + " "+UnidadMedida+" - " + "S/. " + Precio;
		        }
		        #endregion

		    }

 		}

 	}

 }