using MaestroDetalle.DAL;
using MaestroDetalle.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaestroDetalle.BLL
{
   public class ZapatosBLL
    {
        public static bool Guardar(Zapatos zapato)
        {
            if (!Existe(zapato.ZapatoId))
                return Insertar(zapato);
            else
                return Modificar(zapato);
        }

        private static bool Existe(int zapatoId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Zapatos.Any(x => x.ZapatoId == zapatoId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Zapatos zapato)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Zapatos.Add(zapato);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Zapatos zapato)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(zapato).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static Zapatos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Zapatos zapato;
            try
            {
                zapato = contexto.Zapatos.Find(id);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return zapato;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(id);
                if(item != null)
                {
                    contexto.Zapatos.Remove(item);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static List<Zapatos> GetList(Expression<Func<Zapatos, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Zapatos> lista = new List<Zapatos>();

            try
            {
                lista = contexto.Zapatos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
        
    }
}
