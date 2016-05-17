﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M6;

namespace Tangerine.GUI.M6
{
    public partial class AgregarRequerimiento : System.Web.UI.Page
    {
        int idPropuesta;
        int idprop;
        public List<Propuesta> Prueba;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void btn_Modifica(String idPropuesta, object sender, EventArgs e)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();
            
            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);
            

        }

    }
}