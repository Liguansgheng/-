using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCMLIB
{
    public abstract class VR
    {
        protected TransferSyntax syntax;
        public VR(TransferSyntax syntax)
        {
            this.syntax = syntax;
        }

        public abstract byte[] WriteValue<T>(T[] val);
        public abstract T[] ReadValue<T>(byte[] data);

        public double GetDouble(byte[] data, ref uint idx)
        {
            Double doublE;
            if (syntax.isBE == true)
            {
                Array.Reverse(data);
                doublE = BitConverter.ToSingle(data, 0);
            }
            else
                doublE = BitConverter.ToSingle(data, 0);
            return doublE;

        }

        public float GetSingle(byte[] data,ref uint idx)
        {
            Single single;
            if (syntax.isBE == true)
            {
                Array.Reverse(data);
                single = BitConverter.ToSingle(data, (int)idx);
            }
            else
                single = BitConverter.ToSingle(data, (int)idx);
            idx += 4;
            return single;

        }

        public virtual uint GetLength(byte[] data, ref uint idx)  //读取值长度
        {
            uint length = 0;
            if (syntax.isExplicit == true)
                length = GetUShort(data, ref idx);
            else
                length = GetUInt(data, ref idx);
            return length;
        }

        public abstract string GetString(byte[] data, string head);

        public string Getstring(byte[] data)
        {
            String s = Encoding.Default.GetString(data);
            return s;
        }

        public uint GetUInt(byte[] data, ref uint idx)     //解码longVR的值长度用到了
        {
            uint UInt = 0 ;
            if (syntax.isBE == true)     //BE
                 UInt = (uint)(data[idx + 1] + (data[idx] << 8) + (data[idx + 3] << 16) + (data[idx + 2]<< 24));
            else                         //LE
               //UInt = (uint)(BitConverter.ToUInt32(data, (int)idx));
                 UInt = (uint)(data[idx] + (data[idx + 1] << 8) + (data[idx + 2] << 16) + (data[idx + 3] << 24));
            idx += 4;
            return UInt;
        }

        public int GetInt(byte[] data, ref uint idx)    //SL
        {
            int num;
            if (syntax.isBE == true)
            {
                Array.Reverse(data);
                num = BitConverter.ToInt32(data, 0);
            }
            else
                num = BitConverter.ToInt32(data, 0);
            return num;
        }

        public short GetShort(byte[] data, ref uint idx)    //SS
        {
            short num;
            if (syntax.isBE == true)
            {
                Array.Reverse(data);
                num = BitConverter.ToInt16(data, 0);
            }
            else
                num = BitConverter.ToInt16(data, 0);
            return num;
        }

        public ushort GetUShort(byte[] data, ref uint idx)   //US
        {
            ushort UShort;
            if (syntax.isBE == true)     //BE
                 UShort = (ushort)(data[idx + 1] + (data[idx] << 8));
            else                         //LE
                 UShort = (ushort)(data[idx] + (data[idx + 1] << 8));
            idx += 2;
            return UShort;
        }

        public ushort GetElementTag(byte[] data, ref uint idx)   //解码tag
        {
            ushort ElementTag;
            if (syntax.isBE == false)
                ElementTag = (ushort)(data[idx] + data[idx + 1] << 8);
            else
                ElementTag = (ushort)(data[idx + 1] + data[idx] << 8);
            idx += 2;
            return ElementTag;
        }

        public ushort GetGroupTag(byte[] data, ref uint idx)   //解码tag
        {
            ushort GroupTag;
            if (syntax.isBE == false)
                GroupTag = (ushort)(data[idx] + data[idx + 1] << 8);
            else
                GroupTag = (ushort)(data[idx + 1] + data[idx] << 8);
            idx += 2;
            return GroupTag;
        }

        public virtual byte[] GetValue(byte[] data ,ref uint idx ,uint length)  //抓取value
        {
            byte[] value = data.Skip((int)idx).Take((int)length).ToArray();
            idx += length;
            return value;
        }

        public string GetVR(byte[] data, ref uint idx)    //解码VR
        {
            string vr;
            if (syntax.isExplicit ==true)     //显式VR
            {
                vr = Encoding.Default.GetString(data, (int)idx, 2);
                idx += 2;
            }
            else
                vr = "";
            return vr;
        }
    }

    public class UL : VR  //无符号长整形
    {
        public UL(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            uint value = GetUInt(data, ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            if (typeof(T) == typeof(uint))    //判断是否请求的是对应的uint类型
            {
                uint[] vals = val as uint[];
                //暂时先考虑单个值,多值有待完善
                byte[] data = BitConverter.GetBytes(vals[0]);
                if (syntax.isBE)
                    Array.Reverse(data);
                return data;
            }
            throw new NotSupportedException();
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(uint)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                uint[] val = new uint[1];
                int idx = 0;
                if (syntax.isBE)
                    val[0] = (uint)((data[idx] << 24) + (data[idx + 1] << 16) + (data[idx + 2] << 8) + data[idx + 3]);
                else
                    val[0] = (uint)((data[idx + 3] << 24) + (data[idx + 2] << 16) + (data[idx + 1] << 8) + data[idx]);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class SS:VR
    {
        public SS(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            short value = GetShort(data,ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(short)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                short[] val = new short[1];
                int idx = 0;
                if (syntax.isBE)
                    val[0] = (short)((data[idx] << 8) + data[idx + 1]);
                else
                    val[0] = (short)((data[idx + 1] << 8) + data[idx]);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class SL:VR
    {
        public SL(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            int value = GetInt(data, ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(int)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                int[] val = new int[1];
                int idx = 0;
                if (syntax.isBE)
                    val[0] = (data[idx] << 24) + (data[idx + 1] << 16) + (data[idx + 2] << 8) + data[idx + 3];
                else
                    val[0] = (data[idx + 3] << 24) + (data[idx + 2] << 16) + (data[idx + 1] << 8) + data[idx];
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class US:VR
    {
        public US(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            ushort value = GetUShort(data, ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(ushort)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                ushort[] val = new ushort[1];
                int idx = 0;
                if (syntax.isBE)
                    val[0] = (ushort)((data[idx] << 8) + data[idx + 1]);
                else
                    val[0] = (ushort)((data[idx + 1] << 8) + data[idx]);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class IS:VR
    {
        public IS(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            //int value = int.Parse(value);  //十进制整型字符串
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(string)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                string[] val = new string[1];
                val[0] = Getstring(data);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class FL:VR
    {
        public FL(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            Single value = GetSingle(data, ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(Single)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                Single[] val = new Single[1];
                uint idx = 0;
                val[0] = GetSingle(data,ref idx);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class FD:VR
    {
        public FD(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            uint idx = 0;
            Double value = GetDouble(data, ref idx);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class DS:VR
    {
        public DS(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            //Double value = Double.Parse(value);  //十进制小数字符串
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(string)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                string[] val = new string[1];
                val[0] = Getstring(data);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class DA:VR
    {
        public DA(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            int year = int.Parse(value.Substring(0, 4));
            int month = int.Parse(value.Substring(4, 2));
            int day = int.Parse(value.Substring(6, 2));
            DateTime dt = new DateTime(year, month, day);
            return dt.ToShortDateString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class TM:VR
    {
        public TM(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            int hour = int.Parse(value.Substring(0, 2));
            int minute = int.Parse(value.Substring(2, 2));
            int second = int.Parse(value.Substring(4, 2));
            int milli = int.Parse(value.Substring(7, 6));
            TimeSpan ts = new TimeSpan(0, hour, minute, second, milli);
            return ts.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class DT:VR
    {
        public DT(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            return "没写";
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class SH:VR
    {
        public SH(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class LO : VR
    {
        public LO(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class ST : VR
    {
        public ST(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            if (typeof(T) == typeof(string)) //判断是否请求的是对应的uint类型
            {
                //暂时先考虑单个值,多值有待完善
                string[] val = new string[1];
                val[0] = Getstring(data);
                return val as T[];
            }
            throw new NotSupportedException();
        }
    }

    public class LT : VR
    {
        public LT(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class UI : VR
    {
        public UI(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class PN : VR
    {
        public PN(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class AE : VR
    {
        public AE(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class AS : VR
    {
        public AS(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            string value = Getstring(data);
            return value.ToString();
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }

    public class CS : VR
    {
        public CS(TransferSyntax syntax) : base(syntax) { }
        public override string GetString(byte[] data, string head)
        {
            return "没写";
        }

        public override byte[] WriteValue<T>(T[] val)
        {
            byte[] data = new byte[5];
            return data;
        }
        public override T[] ReadValue<T>(byte[] data)
        {
            T[] value = new T[5];
            return value;
        }
    }
}