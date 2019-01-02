using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public class A01 : compositeMessage
    {
        public A01() : base(null, "A01")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN Evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH Msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID Pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 Pv1
        {
            get { return data[3] as PV1; }
            set { data[3] = value; }
        }
    }

    public class A02 : compositeMessage
    {
        public A02() : base(null, "A02")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN Evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH Msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID Pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 Pv1
        {
            get { return data[3] as PV1; }
            set { data[3] = value; }
        }
    }

    public class A03 : compositeMessage
    {
        public A03() : base(null, "A03")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN Evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH Msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID Pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 Pv1
        {
            get { return data[3] as PV1; }
            set { data[3] = value; }
        }
    }

    public class A04 : compositeMessage
    {
        public A04() : base(null, "A04")
        {
            data = new abstractType[4];
            data[0] = new EVN(this);
            data[1] = new MSH(this);
            data[2] = new PID(this);
            data[3] = new PV1(this);
        }
        public EVN Evn
        {
            get { return data[0] as EVN; }
            set { data[0] = value; }
        }
        public MSH Msh
        {
            get { return data[1] as MSH; }
            set { data[1] = value; }
        }
        public PID Pid
        {
            get { return data[2] as PID; }
            set { data[2] = value; }
        }
        public PV1 Pv1
        {
            get { return data[3] as PV1; }
            set { data[3] = value; }
        }
    }

    public class ACK : compositeMessage
    {
        public ACK() : base(null, "ACK")
        {
            data = new abstractType[2];
            data[0] = new MSH(this);
            data[1] = new MSA(this);
        }
        public MSH Msh
        {
            get { return data[0] as MSH; }
            set { data[0] = value; }
        }
        public MSA Msa
        {
            get { return data[1] as MSA; }
            set { data[1] = value; }
        }
    }

    public class O01 : compositeMessage
    {
        public O01() : base(null, "O01")
        {
            data = new abstractType[5];
            data[0] = new MSH(this);
            data[1] = new PID(this);
            data[2] = new PV1(this);
            data[3] = new ORC(this);
            data[4] = new OBR(this);
        }
        public MSH Msh
        {
            get { return data[0] as MSH; }
            set { data[0] = value; }
        }
        public PID Pid
        {
            get { return data[1] as PID; }
            set { data[1] = value; }
        }
        public PV1 Pv1
        {
            get { return data[2] as PV1; }
            set { data[2] = value; }
        }
        public ORC Orc
        {
            get { return data[3] as ORC; }
            set { data[3] = value; }
        }
        public OBR Obr
        {
            get { return data[4] as OBR; }
            set { data[4] = value; }
        }
    }
}
