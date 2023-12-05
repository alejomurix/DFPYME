using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCaja
    {
        private DaoCaja miDaoCaja;

        public BussinesCaja()
        {
            this.miDaoCaja = new DaoCaja();
        }

        public void Ingresar(Caja caja)
        {
            miDaoCaja.Ingresar(caja);
        }

        public Caja CajaId(int id)
        {
            return miDaoCaja.CajaId(id);
        }

        public Caja CajaNumero(int numero)
        {
            return miDaoCaja.CajaNumero(numero);
        }

        public DataTable Cajas()
        {
            return miDaoCaja.Cajas();
        }

        public DataTable CajasOrder()
        {
            var cajas = miDaoCaja.Cajas();
            var row = cajas.NewRow();
            row["idcaja"] = 0;
            row["numerocaja"] = 0;
            cajas.Rows.Add(row);
            return cajas.AsEnumerable().OrderBy(r => r.Field<int>("numerocaja")).CopyToDataTable();
        }

        public void ReservarCaja(int id)
        {
            miDaoCaja.ReservarCaja(id);
        }

        public int Consecutivo(int id)
        {
            return miDaoCaja.Consecutivo(id);
        }

        public void ActualizarConsecutivo(int id)
        {
            miDaoCaja.ActualizarConsecutivo(id);
        }


        public string PrefijoNumeroFactura(int idCaja)
        {
            return this.miDaoCaja.PrefijoFactura(idCaja);
        }

        /*public void ActualizarConsecutivoFactura(int idCaja)
        {
            this.miDaoCaja.ActualizarConsecutivoFactura(idCaja);
        }*/

        // Consecutivo General
        public int ConsecutivoGeneral()
        {
            return miDaoCaja.ConsecutivoGeneral();
        }

        public void ActualizarConsecutivoGeneral()
        {
            miDaoCaja.ActualizarConsecutivoGeneral();
        }
    }
}