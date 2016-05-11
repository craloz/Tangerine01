﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Propuesta
    {
        #region Atributos

        /// <summary>
        /// Clase propuesta
        /// <attr name="_codigo">Codigo unico indentificador de la propuesta</attr>
        /// <attr name="_nombre">nombre con el que se identificara a la propuesta</attr>
        /// <attr name="_descripcion">Descripcion breve sobre la propuesta</attr>
        /// <attr name="_duracion">duracion estimada de la propuesta {Meses, Dias, Horas}</attr>
        /// <attr name="_acuerdopago">tipo de compromiso de pago al cual se va a llegar para la propuesta</attr>
        /// <attr name="_estatus">Estado en el que se encuentra la propuesta {Aprobada, Pendiente, Cerrada}</attr>
        /// <attr name="_moneda">Moneda base de pago para la propuesta de proyecto</attr>
        /// <attr name="_entrega">Dependiendo del compromiso de pago se llegara a una cantidad de entregas estipuladas </attr>
        /// <attr name="_feincio">fecha estimada de inicio </attr>
        /// <attr name="_fefinal">fecha estimada de fin </attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// <attr name="_listaCompania">lista de las compañias de las cuales se puede generar una propuesta</attr> 
        /// <attr name="_listaRequerimiento">lista de requerimientos asociados a un proyecto</attr> 
        /// </summary>

        private string _codigoP;
        private string _nombre;
        private string _descripcion;
        private string _duracion;
        private string _acuerdopago;
        private string _estatus;
        private string _moneda;
        private int _entrega;
        private DateTime _feincio;
        private DateTime _fefinal;
        private int _costo;

        private List<Compania> _listaCompania;
        private List<Requerimiento> _listaRequerimiento;

        #endregion

        #region Propiedades

        public string CodigoP
        {
            get { return _codigoP; }
            set { _codigoP = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }
        public string Acuerdopago
        {
            get { return _acuerdopago; }
            set { _acuerdopago = value; }
        }
        public string Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public string Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }
        public int Entrega
        {
            get { return _entrega; }
            set { _entrega = value; }
        }
        public DateTime Feincio
        {
            get { return _feincio; }
            set { _feincio = value; }
        }
        public DateTime Fefinal
        {
            get { return _fefinal; }
            set { _fefinal = value; }
        }
        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        public List<Compania> ListaCompania
        {
            get { return _listaCompania; }
            set { _listaCompania = value; }
        }


        #endregion

        #region Constructor

        public Propuesta()
        {

        }

        public Propuesta(string codigoP, string nombre, string descripcion, string duracion, string acuerdopago, string estatus,
                         string moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, List<Compania> listaCompania,
                         List<Requerimiento> listaRequerimiento)
        {
            this._codigoP = codigoP;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._duracion = duracion;
            this._acuerdopago = acuerdopago;
            this._estatus = estatus;
            this._moneda = moneda;
            this._entrega = entrega;
            this._feincio = feincio;
            this._fefinal = fefinal;
            this._costo = costo;
            this._listaCompania = listaCompania;
            this._listaRequerimiento = listaRequerimiento;

        }

        #endregion

    }
}