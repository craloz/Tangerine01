﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M9;
using LogicaTangerine;
using DominioTangerine;
using System.Windows.Forms;

namespace Tangerine_Presentador.M9
{
    public class PresentadorSeleccionCompania
    {

        IContratoSeleccionCompania vista;

        /// <summary>
        /// Constructor del Presentador para implementar en GUI
        /// </summary>
        /// <param name="vista">Interfaz del Contrato con firma de metodos utilizados por el Presentador</param>
        public PresentadorSeleccionCompania (IContratoSeleccionCompania vista)
        {

            this.vista = vista;

        }
    
        /// <summary>
        /// Metodo para llenar tabla con todas las companias registradas en el sistema
        /// </summary>
        public void LlenarCompanias ()
        {
            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania();

            List<Entidad> ListComp = comando.Ejecutar();

            try
                {
                    foreach (Entidad theCompany in ListComp)
                    {
                        vista.company += RecursoPresentadorM9.OpenTR;

                        vista.company += RecursoPresentadorM9.OpenTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).NombreCompania + 
                            RecursoPresentadorM9.CloseTD;
                        vista.company += RecursoPresentadorM9.OpenTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).AcronimoCompania.ToString() + 
                            RecursoPresentadorM9.CloseTD;
                        vista.company += RecursoPresentadorM9.OpenTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).RifCompania + 
                            RecursoPresentadorM9.CloseTD;
                        vista.company += RecursoPresentadorM9.OpenTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).FechaRegistroCompania.ToShortDateString() + 
                            RecursoPresentadorM9.CloseTD;
                        if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(1))
                        {
                            vista.company += RecursoPresentadorM9.OpenTD + RecursoPresentadorM9.habilitado + 
                                RecursoPresentadorM9.CloseTD;
                        }
                        else if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(0))
                        {
                            vista.company += RecursoPresentadorM9.OpenTD + RecursoPresentadorM9.inhabilitado + 
                                RecursoPresentadorM9.CloseTD;
                        }

                        //Boton para cargar las facturas asociadas a cada compañia
                            vista.company += RecursoPresentadorM9.boton + 
                                ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id + 
                                RecursoPresentadorM9.boton_cerrar_id;

                        //Boton para cargar los pagos asociadas a cada compañia
                            vista.company += RecursoPresentadorM9.BotonPagos + 
                                ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id +
                                RecursoPresentadorM9.boton_cerrar_id;
                            vista.company += RecursoPresentadorM9.CerrarTR;
                    }

                }
            catch (ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine ex)
            {
                MessageBox.Show("Error, llene todos los campos", "Campos Vacios", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            catch (ExcepcionesTangerine.M9.ExceptionDataBaseM9Tangerine ex)
            {
                MessageBox.Show("Error en la conexion a la Base de Datos", "Error de Conexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine ex)
            {
                MessageBox.Show("Error, Formato Incorrecto en Codigo de Aprobacion", "Formato Incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    
    }
}