using AutoMapper;
using Inke.Common.Exceptions;
using InkeServer.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoMapper
{
    public static class AutoMapperExtensions
    {
        /// <summary>   
        /// 集合对集合     
        /// </summary>   
        /// <typeparam name="TTarget"></typeparam>   
        /// <param name="source"></param>   
        /// <returns></returns>   
        public static List<TTarget> MapTo<TTarget>(this IEnumerable source)
        {
            if (source == null) 
                throw new BusinessException(ResultCode.ArgumentsMiss.Value().ToString());

            Mapper.CreateMap(source.GetType(), typeof(TTarget));
            return (List<TTarget>)Mapper.DynamicMap(source, source.GetType(), typeof(List<TTarget>));
        }

        /// <summary>   
        /// 对象对对象   
        /// </summary>   
        /// <typeparam name="TTarget"></typeparam>   
        /// <param name="source"></param>   
        /// <returns></returns>  
        public static TTarget MapTo<TTarget>(this object source)
        {
            if (source == null)
                throw new BusinessException(ResultCode.ArgumentsMiss.Value().ToString());

            Mapper.CreateMap(source.GetType(), typeof(TTarget));
            return (TTarget)Mapper.DynamicMap(source, source.GetType(), typeof(TTarget));
        }

    }
}
