using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ESantiagoPruebaTecnicaNovEntities context = new DL.ESantiagoPruebaTecnicaNovEntities())
                {
                    var query = (from disco in context.Discoes
                                 select new
                                 {
                                     IdDisco = disco.IdDisco,
                                     Nombre = disco.Nombre,
                                     Artista = disco.Artista,
                                     FechaEstreno = disco.FechaEstreno,
                                     Costo = disco.Costo
                                 });
                    if(query!= null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = item.IdDisco;
                            disco.Nombre = item.Nombre;
                            disco.Artista = item.Artista;
                            disco.FechaEstreno = item.FechaEstreno;
                            disco.Costo = item.Costo;
                            result.Objects.Add(disco);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido recuperar los discos.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int idDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoPruebaTecnicaNovEntities context = new DL.ESantiagoPruebaTecnicaNovEntities())
                {
                    var query = (from disco in context.Discoes where disco.IdDisco == idDisco
                                 select new
                                 {
                                     IdDisco = disco.IdDisco,
                                     Nombre = disco.Nombre,
                                     Artista = disco.Artista,
                                     FechaEstreno = disco.FechaEstreno,
                                     Costo = disco.Costo
                                 }).AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        result.Object = new object();

                        ML.Disco disco = new ML.Disco();
                        disco.IdDisco = query.IdDisco;
                        disco.Nombre = query.Nombre;
                        disco.Artista = query.Artista;
                        disco.FechaEstreno = query.FechaEstreno;
                        disco.Costo = query.Costo;

                        result.Object = disco;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido recuperar el disco.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int idDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoPruebaTecnicaNovEntities context = new DL.ESantiagoPruebaTecnicaNovEntities())
                {
                    var query = (from disco in context.Discoes
                                 where disco.IdDisco == idDisco
                                 select disco).Single();
                    if (query != null)
                    {
                        context.Discoes.Remove(query);
                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se ha podido recuperar los discos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new Result();
            try
            {
                using(DL.ESantiagoPruebaTecnicaNovEntities context = new DL.ESantiagoPruebaTecnicaNovEntities())
                {
                    DL.Disco nuevoDisco = new DL.Disco();
                    nuevoDisco.Nombre = disco.Nombre;
                    nuevoDisco.Artista = disco.Artista;
                    nuevoDisco.FechaEstreno = disco.FechaEstreno;
                    nuevoDisco.Costo = disco.Costo;
                    context.Discoes.Add(nuevoDisco);
                    int rowsAffected = context.SaveChanges();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido agregar el disco.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ESantiagoPruebaTecnicaNovEntities context = new DL.ESantiagoPruebaTecnicaNovEntities())
                {
                    var query = (from disc in context.Discoes
                                 where disco.IdDisco == disco.IdDisco
                                 select disc).Single();
                    if (query != null)
                    {
                        query.Nombre = disco.Nombre;
                        query.Artista = disco.Artista;
                        query.FechaEstreno = disco.FechaEstreno;
                        query.Costo = disco.Costo;
                        int rowsAffected = context.SaveChanges();
                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "Error al actualizar el disco.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
