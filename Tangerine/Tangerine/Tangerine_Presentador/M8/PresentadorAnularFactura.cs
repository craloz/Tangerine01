﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M8;
using LogicaTangerine;
using DominioTangerine;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;
using LogicaTangerine.Fabrica;
using System.Web;

namespace Tangerine_Presentador.M8
{
    public class PresentadorAnularFactura
    {
        IContratoAnularFactura vista;

        public PresentadorAnularFactura(IContratoAnularFactura vista)
        {
            this.vista = vista;
        }

        public void cargarFactura()
        {
            try
            {
                Facturacion lafactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                lafactura.Id = int.Parse(this.vista.numero);

                Comando<Entidad> comando = FabricaComandos.CrearConsultarXIdFactura(lafactura);
                lafactura = (Facturacion)comando.Ejecutar();

                vista.numero = this.vista.numero;
                vista.fecha = lafactura.fechaFactura.ToString(RecursoPresentadorM8.dateTipe);
                vista.compania = lafactura.idCompaniaFactura.ToString();
                vista.proyecto = lafactura.idProyectoFactura.ToString();
                vista.descripcion = lafactura.descripcionFactura;
                vista.monto = lafactura.montoFactura.ToString();
                vista.moneda = lafactura.tipoMoneda;
            }
            catch (Exception e)
            {

            }

        }

        public void anularFactura()
        {
            try
            {
                Facturacion lafactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                lafactura.Id = int.Parse(this.vista.numero);
                //Comando<Entidad> comandoAnular = FabricaComandos.CrearAnularFactura(lafactura);
            }
            catch (Exception e)
            {

            }
        }
    }
}
