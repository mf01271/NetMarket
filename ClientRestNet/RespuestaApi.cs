﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet
{
    [DataContract]
    public class RespuestaApi<T>
    {

        [DataMember]
        public int Codigo
        {
            get;
            set;
        }

        [DataMember]
        public string FechaHora
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssss"); }
            set {; }
        }

        [DataMember]
        public string Mensaje
        {
            get;
            set;
        }

        [DataMember]
        public T Data
        {
            get;
            set;
        }

        public static RespuestaApi<T> createRespuestaError(string mensaje)
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = 1;
            respuesta.Mensaje = mensaje;
            return respuesta;
        }
        public static RespuestaApi<T> createRespuestaErrorTocken()
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = 3;
            respuesta.Mensaje = "Otro dispositivo ha iniciado sesión con este usuario, inicie sesión nuevamente para continuar.";
            return respuesta;
        }

        public static RespuestaApi<T> createRespuestaError(int codigo, string mensaje)
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = codigo;
            respuesta.Mensaje = mensaje;
            return respuesta;
        }

        public static RespuestaApi<string> createRespuestaEncriptedSuccess(string mensaje, string data)
        {

            RespuestaApi<string> respuesta = new RespuestaApi<string>();
            respuesta.Codigo = 0;
            respuesta.Mensaje = mensaje;
            respuesta.Data = data;
            return respuesta;
        }

        public static RespuestaApi<T> createrespuestasuccess(string mensaje)
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = 0;
            respuesta.Mensaje = mensaje;
            return respuesta;
        }

        public static RespuestaApi<T> createrespuestasuccess(string mensaje, T data)
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = 0;
            respuesta.Mensaje = mensaje;
            respuesta.Data = data;
            return respuesta;
        }

        public static RespuestaApi<T> createRespuestaSuccess(T data)
        {
            RespuestaApi<T> respuesta = new RespuestaApi<T>();
            respuesta.Codigo = 0;
            respuesta.Mensaje = "Success";
            respuesta.Data = data;
            return respuesta;
        }
    }
}
