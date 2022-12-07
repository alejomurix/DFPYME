using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesPuc
    {
        private DaoPuc miDaoPuc;

        public BussinesPuc()
        {
            this.miDaoPuc = new DaoPuc();
        }

        public bool ExisteClase(string numero)
        {
            return miDaoPuc.ExisteClase(numero);
        }

        public bool ExisteGrupo(string numero)
        {
            return miDaoPuc.ExisteGrupo(numero);
        }

        public bool ExisteCuenta(string numero)
        {
            return miDaoPuc.ExisteCuenta(numero);
        }

        public bool ExisteSubCuenta(string numero)
        {
            return miDaoPuc.ExisteSubCuenta(numero);
        }

        public int IngresarClase(ClasePuc clase)
        {
            return miDaoPuc.IngresarClase(clase);
        }

        public int IngresarGrupo(GrupoPuc grupo)
        {
            return miDaoPuc.IngresarGrupo(grupo);
        }

        public int IngresarCuenta(CuentaPuc cuenta)
        {
            return miDaoPuc.IngresarCuenta(cuenta);
        }

        public int IngresarSubCuenta(SubCuentaPuc sCuenta)
        {
            return miDaoPuc.IngresarSubCuenta(sCuenta);
        }

        public DataTable Clases()
        {
            return miDaoPuc.Clases();
        }

        public DataTable Clases(int id)
        {
            return miDaoPuc.Clases(id);
        }

        public DataTable Grupos(int idClase)
        {
            return miDaoPuc.Grupos(idClase);
        }

        public DataTable GrupoId(int id)
        {
            return miDaoPuc.GrupoId(id);
        }

        public DataTable Cuentas(int idGrupo)
        {
            return miDaoPuc.Cuentas(idGrupo);
        }

        public DataTable Cuenta(int id)
        {
            return miDaoPuc.Cuenta(id);
        }

        public DataTable SubCuentas(int idCuenta)
        {
            return miDaoPuc.SubCuentas(idCuenta);
        }

        public DataTable SubCuentaId(int id)
        {
            return miDaoPuc.SubCuentaId(id);
        }

        public DataTable CuentasDelPuc(int idClase)
        {
            return miDaoPuc.CuentasDelPuc(idClase);
        }

        public string GetSubCuenta(int idSubcuenta)
        {
            return miDaoPuc.GetSubCuenta(idSubcuenta);
        }

        public CuentaPuc Cuenta(string numero)
        {
            return miDaoPuc.Cuenta(numero);
        }

        public CuentaPuc CuentaPuc(string numero)
        {
            return miDaoPuc.CuentaPuc(numero);
        }

        public void EditarSubCuenta(int id, bool estado)
        {
            miDaoPuc.EditarSubCuenta(id, estado);
        }

        public bool ExisteSubCuentas(int idClase)
        {
            return miDaoPuc.ExisteSubCuentas(idClase);
        }


        // Relacion de Cuentas
        public long GetRowsRelacion()
        {
            return miDaoPuc.GetRowsRelacion();
        }

        public DataTable Relaciones()
        {
            return miDaoPuc.Relaciones();
        }

        public void IngresarRelacion(SubCuentaPuc cuenta)
        {
            miDaoPuc.IngresarRelacion(cuenta);
        }

        public void EditarRelacion(SubCuentaPuc cuenta)
        {
            miDaoPuc.EditarRelacion(cuenta);
        }
    }
}