﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using Tangerine_Contratos.M1;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M1
{
    public partial class CrearEmpleado : System.Web.UI.Page, IContratoCrearEmpleado
    {
        private PresentadorCrearEmpleado presentador;      
        private string[] Substrings;
        private string fecha;



        public CrearEmpleado()
        {
            presentador = new PresentadorCrearEmpleado(this);
        }

        /// <summary>
        /// Carga la ventana Registrar Empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            #region LLENAR combo de genero
            if (!IsPostBack)
            {                
                presentador.LlenarComboEmpleado();
                presentador.LlenarComboNivelEstudio();
                presentador.ObtenerPaises();
                presentador.ObtenerCargos();
            }
            #endregion
        }

        /// <summary>
        /// Carga combobox de Pais
        /// </summary>
        protected void SelectedCountry_Change(object sender, EventArgs e)
        {

            presentador.SelectedPaisChanged();


        }

        /// <summary>
        /// Boton Registrar al Empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
           
               
                if (Page.IsValid)
                {
                    presentador.AgregarEmpleado();         

                }

        }


        #region Contrato

        DropDownList IContratoCrearEmpleado.IcomboGenero
        {
            get { return SelectedListGender; }
            set { SelectedListGender = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboNivelEstudio
        {
            get { return LevelListStudy; }
            set { LevelListStudy = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboPais
        {
            get { return SelectedListCountry; }
            set { SelectedListCountry = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboCargo
        {
            get { return SelectedListJob; }
            set { SelectedListJob = value; }
        }
        DropDownList IContratoCrearEmpleado.IcomboEstado
        {
            get { return SelectedListState; }
            set { SelectedListState = value; }
        }

        String IContratoCrearEmpleado.ItextCedula
        {
            get { return Cedula.Value; }
            set { Cedula.Value = value; }
        }

        String IContratoCrearEmpleado.ItextFirstName
        {
            get { return FirstName.Value; }
            set { FirstName.Value = value; }
        }
        String IContratoCrearEmpleado.ItextSecondNamee
        {
            get { return SecondNamee.Value; }
            set { SecondNamee.Value = value; }
        }
        String IContratoCrearEmpleado.ItextFirstLastName
        {
            get { return FirstLastName.Value; }
            set { FirstLastName.Value = value; }
        }
        String IContratoCrearEmpleado.ItextSecondLastName
        {
            get { return SecondLastName.Value; }
            set { SecondLastName.Value = value; }
        }
        String IContratoCrearEmpleado.ItextDateEmployee
        {
            get
            {
                Substrings = DateEmployee.Value.ToString().Split('-');
                fecha = Substrings[1] + '/' + Substrings[2] + '/' + Substrings[0];
                return fecha;
            }
            set { DateEmployee.Value = value; }
        }
        String IContratoCrearEmpleado.ItextDateJob
        {
            get
            {
                Substrings = DateEmployee.Value.ToString().Split('-');
                fecha = Substrings[1] + '/' + Substrings[2] + '/' + Substrings[0];
                return fecha;
            }
            set { DateJob.Value = value; }
        }
        String IContratoCrearEmpleado.ItextJobMode
        {
            get { return JobMode.Value; }
            set { JobMode.Value = value; }
        }
        String IContratoCrearEmpleado.ItextSalaryJob
        {
            get { return SalaryJob.Value; }
            set { SalaryJob.Value = value; }
        }
        String IContratoCrearEmpleado.ItextCityAddress
        {
            get { return CityAddress.Value; }
            set { CityAddress.Value = value; }
        }
        String IContratoCrearEmpleado.ItextAddresEspecific
        {
            get { return AddresEspecific.Value; }
            set { AddresEspecific.Value = value; }
        }
        String IContratoCrearEmpleado.ItextEmailPerson
        {
            get { return EmailPerson.Value; }
            set { EmailPerson.Value = value; }
        }
        String IContratoCrearEmpleado.ItextPhonePerson
        {
            get { return PhonePerson.Value; }
            set { PhonePerson.Value = value; }
        }



        #endregion


    }
}