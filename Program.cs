using System;
using System.Collections.Generic;
//PARA INTERFACES
using interfaces.consulta;
//PARA ORGANIZACION
using organizacion.rrhh.empleados;
using organizacion.rrhh.consumidores;
//PARA LOGISTICA
using logistica.infraestructura;
using logistica.produtos;
using logistica.produtos.bebibles;
using logistica.produtos.consumibles;


/*
 Nombre : John Alexander Soto Tagle
 Codigo: 20161312
 Fecha: 22/04/2021
*/

 namespace ventas{
 	class LineaOrdenVenta
    {
        #region Propiedades
        private double _subTotal;
        private ItemVenta itemVenta;
        private int _cant;
        #endregion

        #region Constructor
        public LineaOrdenVenta(ItemVenta item, int cant)
        {
            Item = item;
            Cant = cant;
        }
        #endregion

        #region Getters y Setters
        public int Cant
        {
            get { return _cant; }
            set { _cant = value; }
        }

        public ItemVenta Item
        {
            get { return itemVenta; }
            set { itemVenta = value; }
        }

        public double SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        #endregion

        #region Metodos
        public void calcularSubTotal()
        {
            SubTotal = Item.Precio * Cant;
        }

        public String generarImpresion()
        {
            return Item.consultarDatos()+" -"+Cant.ToString("0.##") + " - S/. "+SubTotal.ToString("0.##");
        }

        #endregion
    }

    class OrdenVenta
    {
        public const int max = 50;
        #region Propiedades
        private int _id;
        private double _total;
        private Mesero _mesero;
        private Mesa _mesa;
        private List<LineaOrdenVenta> _lineas;
        private Cliente cliente;
        #endregion

        #region Constructor
        public OrdenVenta(int id)
        {
            Id = id;
            _lineas = new List<LineaOrdenVenta>();
        }
        #endregion

        #region Getters y Setters
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }
        public Cliente Clientep
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public Mesero Meserop
        {
            get { return _mesero; }
            set { _mesero = value; }
        }
        public Mesa Mesap
        {
            get { return _mesa; }
            set { _mesa = value; }
        }
        public List<LineaOrdenVenta> Lineas
        {
            get { return _lineas; }
            set { _lineas = value; }
        }
        #endregion

        #region Metodos
        public void agregarLineaOrdenVenta(LineaOrdenVenta linea)
        {
            Lineas.Add(linea);
        }
        public void calcularSubtotalesyTotal()
        {
            foreach (var linea  in Lineas)
            {
                linea.calcularSubTotal();
                Total += linea.SubTotal;
            }
        }
        public string generarReporte()
        {
            string reporte="";
            reporte += "Reporte Orden Nro. " + Id + "\n";
            for (int i = 0; i < max; i++) reporte+='-';
            reporte+='\n';

            reporte += "Mesa Nro." + Mesap.Id + "\n";
            reporte +=  Meserop.consultarDatos()+ "\n";
            reporte +=  Clientep.consultarDatos()+"\n";
            for (int i = 0; i < max; i++) reporte += '-';
            reporte += '\n';
            foreach (var linea in Lineas)
            {
                reporte += linea.generarImpresion() + "\n";
            }
            for (int i = 0; i < max; i++) reporte += '-';
            reporte += '\n';
            reporte += "TOTAL : s/. " + Total.ToString("0.##") + "\n";
            return reporte;
        }
        #endregion
    }
 }