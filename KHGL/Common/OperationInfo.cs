using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;

namespace Maticsoft.Common
{
    public class OperationInfo
    {
        #region 遍历个不为空的实体类列赋值
        /// <summary>
        /// 遍历个不为空的实体类列赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldModel">需要修改实体类</param>
        /// <param name="newModel">传值实体类</param>
        /// <returns>赋完值的原始实体类</returns>
        public static T BindModelValue<T>(T oldModel, T newModel)
        {
            //获取泛型实体类
            Type t1 = oldModel.GetType();
            Type t2 = newModel.GetType();
            System.Reflection.PropertyInfo[] mPi = t2.GetProperties();


            string oldValue = "";
            string newValue = "";

            for (int i = 0; i < mPi.Length; i++)
            {
                System.Reflection.PropertyInfo pi = mPi[i];

                //判断传值实体类列不是null
                if (pi.GetValue(newModel, null) != null)
                {
                    oldValue = pi.GetValue(oldModel, null).ToString();
                    newValue = pi.GetValue(newModel, null).ToString();
                    if (newValue != "")
                    {
                        //给原始实体赋值
                        t1.GetProperty(pi.Name)?.SetValue(oldModel, pi.GetValue(newModel, null));
                    }
                }
            }

            return oldModel;
        }
        #endregion
    }
}
