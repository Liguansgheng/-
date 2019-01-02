using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public enum enumTypes
    {
        ID, IS, NM, ST, DT, TM, TX, TN, SI, FT, TS,
        FN, PN, CE, HD, DR, XCN, VID, PT, CM, EI, CX, XAD, XTN, DLN, PL, FC, XPN, XON, CWE, CQ, TQ
    }
    public enum enumSegments
    {
        MSH, MSA, PID, PV1, EVN, ERR, ORC, OBR
    }
    public enum enumMessages
    {
        ACK,A01,A02,A03,A04,O01
    }
    public abstract class abstractFactory
    {
        public abstract abstractType Create(compositeType parent, Enum product, string name);
    }

    public class primitiveFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, Enum product, string name)
        {
            primitiveType obj = null; switch ((enumTypes)product)
            {
                case enumTypes.IS: obj = new IS(name); break;
                case enumTypes.ID: obj = new ID(name); break;   //添加其他简单类型
                case enumTypes.NM: obj = new NM(name); break;
                case enumTypes.ST: obj = new ST(name); break;
                case enumTypes.DT: obj = new DT(name); break;
                case enumTypes.TM: obj = new TM(name); break;
                case enumTypes.TX: obj = new TX(name); break;
                case enumTypes.TN: obj = new TN(name); break;
                case enumTypes.SI: obj = new SI(name); break;
                case enumTypes.FT: obj = new FT(name); break;
                case enumTypes.TS: obj = new TS(name); break;
            }
            return obj;
        }
    }

    public class fieldFactory : abstractFactory
    {
        primitiveFactory factory = new primitiveFactory();
        public override abstractType Create(compositeType parent, Enum product, string name)
        {
            abstractType obj = null; switch ((enumTypes)product)
            {
                case enumTypes.FN: obj = new FN(parent, name); break;
                case enumTypes.PN: obj = new PN(parent, name); break;
                case enumTypes.CE: obj = new CE(parent, name); break;
                case enumTypes.HD: obj = new HD(parent, name); break;
                case enumTypes.DR: obj = new DR(parent, name); break;
                case enumTypes.XCN: obj = new XCN(parent, name); break;
                case enumTypes.VID: obj = new VID(parent, name); break;
                case enumTypes.PT: obj = new PT(parent, name); break;
                case enumTypes.CM: obj = new CM(parent, name); break;
                case enumTypes.EI: obj = new EI(parent, name); break;
                case enumTypes.CX: obj = new CX(parent, name); break;
                case enumTypes.XAD: obj = new XAD(parent, name); break;
                case enumTypes.XTN: obj = new XTN(parent, name); break;
                case enumTypes.DLN: obj = new DLN(parent, name); break;
                case enumTypes.PL: obj = new PL(parent, name); break;
                case enumTypes.FC: obj = new FC(parent, name); break;
                case enumTypes.XPN: obj = new XPN(parent, name); break;
                case enumTypes.XON: obj = new XON(parent, name); break;
                case enumTypes.CWE: obj = new CWE(parent, name); break;
                case enumTypes.CQ: obj = new CQ(parent, name); break;
                case enumTypes.TQ: obj = new TQ(parent, name); break;
                //......                
                default:  //非复合类型，创建基本类型                     
                    obj = factory.Create(parent, product, name);
                    break;
            }
            return obj;
        }
    }

    public class segmentFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, Enum product, string name)
        {
            abstractType obj = null; switch ((enumSegments)product)
            {
                case enumSegments.MSH: obj = new MSH(parent); break;
                case enumSegments.MSA: obj = new MSA(parent); break;
                case enumSegments.PID: obj = new PID(parent); break;
                case enumSegments.PV1: obj = new PV1(parent); break;
                case enumSegments.EVN: obj = new EVN(parent); break;
                case enumSegments.ERR: obj = new ERR(parent); break;
                case enumSegments.ORC: obj = new ORC(parent); break;//添加其他段                 
                case enumSegments.OBR: obj = new OBR(parent); break;                                                    //...           
            }
            return obj;
        }
    }

    public class messageFactory : abstractFactory
    {
        public override abstractType Create(compositeType parent, Enum product, string name)
        {
            abstractType obj = null; switch ((enumMessages)product)
            {
                case enumMessages.ACK: obj = new ACK(); break;
                case enumMessages.A01: obj = new A01(); break;                 //添加其他HL7消息              
                case enumMessages.A02: obj = new A02(); break;
                case enumMessages.A03: obj = new A03(); break;
                case enumMessages.A04: obj = new A04(); break;
                case enumMessages.O01: obj = new O01(); break;//...            
            }
            return obj;
        }
    }
}

