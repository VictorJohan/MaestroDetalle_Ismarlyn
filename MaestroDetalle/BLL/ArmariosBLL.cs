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
   public class ArmariosBLL
    {
        public static bool Guardar(Armarios armario)
        {
            if (!Existe(armario.ArmarioId))
                return Insertar(armario);
            else
                return Modificar(armario);
        }

        private static bool Existe(int armarioId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Armarios.Any(x => x.ArmarioId == armarioId);
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

        private static bool Insertar(Armarios armario)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            { 
                contexto.Armarios.Add(armario);//Agrega el registro.
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

        private static bool Modificar(Armarios armario)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM ArmarioDetalle WHERE ArmarioId ={armario.ArmarioId}");
                foreach (var item in armario.ArmarioDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(armario).State = EntityState.Modified;
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

        public static Armarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Armarios armario;
            try
            {
                armario = contexto.Armarios.Where(x => x.ArmarioId == id)
                    .Include(y => y.ArmarioDetalle).ThenInclude(z => z.Zapato)
                    .SingleOrDefault();//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return armario;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(id);
                if (item != null)
                {
                    contexto.Armarios.Remove(item);
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

        public static List<Armarios> GetList(Expression<Func<Armarios, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Armarios> lista = new List<Armarios>();

            try
            {
                lista = contexto.Armarios.Where(criterio).Include(X => X.ArmarioDetalle).ThenInclude(z => z.Zapato).ToList();
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
