﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using Tangerine_Contratos.M7;
using Tangerine_Presentador.M7;
using DominioTangerine.Entidades.M7;

namespace Tangerine.GUI.M7
{

    public partial class AgregarProyecto : System.Web.UI.Page, IContratoAgregarProyecto
    {
     

        private PresentadorAgregarProyecto _presentador;

        #region Atributos

        public string NombrePropuesta
        {
            get { return this.inputPropuesta.ToString(); }
            set { this.inputPropuesta.Text = value; }
        }


        public string NombreProyecto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string CodigoProyecto
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.textInputCodigo.Value = value.ToString();
            }
        }

        public string FechaInicio
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FechaFin
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Costo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.textInputCosto.Value = value.ToString();
            }
        }

        public string Porcentaje
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Estatus
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DropDownList IContratoAgregarProyecto.inputPersonal
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        ListBox IContratoAgregarProyecto.inputEncargado
        {
            get
            {
                return this.inputEncargado;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        DropDownList IContratoAgregarProyecto.inputPropuesta
        {
            get
            {
                return this.inputPropuesta;
            }
            set
            {
                //this.inputPropuesta.Text = value.ToString();
            }
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            _presentador = new PresentadorAgregarProyecto (this);
            

           if (!IsPostBack)
           {
               _presentador.CargarPagina();
               
          /*  if( Propuestas.Count > 0 )
            {

                Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[0].IdCompañia),1); 

                for (int i = 0; i < Contactos.Count; i++) 
                {
                   inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
                }
                textInputCosto.Value = Propuestas[0].Costo.ToString();
            }
            for (int i = 0; i < Gerentes.Count; i++)
            {
                
                inputGerente.Items.Add(Gerentes[i].emp_p_nombre+" "+Gerentes[i].emp_p_apellido);
            }
            for (int i = 0; i < Programadores.Count; i++)
            {
                
                inputPersonal.Items.Add(Programadores[i].emp_p_nombre + " " + Programadores[i].emp_p_apellido);
            }*/
           }
        }

        protected void btnAgregarPersonal_Click(object sender, EventArgs e)
        {

            columna2.Visible = true;
            btnGenerar.Enabled = true;
        }

        protected void comboPropuesta_Click(object sender, EventArgs e)
        {

            _presentador.CargarInformacionPropuesta(sender);

           /* inputEncargado.Items.Clear();

            Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia), 1);

            for (int i = 0; i < Contactos.Count; i++)
            {
                inputEncargado.Items.Add(Contactos[i].Nombre + " " + Contactos[i].Apellido);
            }
            
             */
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            /* Propuestas = LogicaM7.ConsultarPropuestasAprobadas();
             Gerentes = LogicaM10.GetGerentes();
             Programadores = LogicaM10.GetProgramadores();
             Contactos = LogicaM5.GetContacts(int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia), 1);
             Proyecto _proyecto = new Proyecto(0,textInputNombreProyecto.Value,textInputCodigo.Value,DateTime.Parse(textInputFechaInicio.Value),
                                               DateTime.Parse(textInputFechaEstimada.Value), Double.Parse(textInputCosto.Value),
                                               Propuestas[inputPropuesta.SelectedIndex].Descripcion, "0", "En desarrollo", "",
                                               Propuestas[inputPropuesta.SelectedIndex].Acuerdopago, int.Parse(Propuestas[inputPropuesta.SelectedIndex].CodigoP), 
                                               int.Parse(Propuestas[inputPropuesta.SelectedIndex].IdCompañia),
                                               Gerentes[inputGerente.SelectedIndex].Emp_num_ficha);
             Empleado _empleado = new Empleado();
             for (int i = 0; i < inputPersonal.Items.Count; i++)
             {
                 if (inputPersonal.Items[i].Selected)
                 {
                     seleccionProgramadores.Add(Programadores[i]);
                 }
             }
            
                
             for (int i = 0; i < inputEncargado.Items.Count; i++)
             {
                 if (inputEncargado.Items[i].Selected)
                 {
                     seleccionContactos.Add(Contactos[i]);
                 }
             }

             _proyecto.set_contactos(seleccionContactos);
             _proyecto.set_empleados(seleccionProgramadores);
           
             LogicaProyecto _logica =  new LogicaProyecto();
             if (_logica.agregarProyecto(_proyecto))
             {
                 Server.Transfer("ConsultaProyecto.aspx");
                 //colocar un mensaje de creacion con exito y vaciar text.
             }
             else
             { 
                 //colocar  un mensaje de error en la creacion
             }*/
        }


    }
}