using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfLife
{
        abstract class CVita
        {
            abstract public bool Morte();
        }
        abstract class CEsserevivente : CVita
        {
            abstract public void Mangia();
            abstract public void Muoversi();
            abstract public void GuadagnaVita();
            abstract public void PerdeVita();
        }
        class CVolpe : CEsserevivente
        {
            private int mVita;
            public int pVita
            {
            get { return mVita; }
            set { mVita = 100; }
            }
            public override bool Morte()
            {
                if(pVita == 0)
                {
                    return true;
                }
                return false;
            }
            public int c;
            public int r;
            public CVolpe(int r, int c)
            {
            this.r = r;
            this.c = c;
            }
            public override void Mangia()
            {
                throw new NotImplementedException();
            }
            public override void Muoversi()
            {
                throw new NotImplementedException();
            }
            public override void GuadagnaVita()
            {
                throw new NotImplementedException();
            }
            public override void PerdeVita()
            {
                pVita--;
                throw new NotImplementedException();
            }
        }
        class CConiglio : CEsserevivente
        {
            private int mVita;
            public int pVita
            {
                get { return mVita; }
                set { mVita = 100; }
            }
            public override bool Morte()
            {
                if (pVita == 0)
                {
                    return true;
                }
                return false;
            }
            public int c;
            public int r;
            public CConiglio(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        public override void Mangia()
            {
                throw new NotImplementedException();
            }
            public override void Muoversi()
            {
                throw new NotImplementedException();
            }
            public override void GuadagnaVita()
            {
                throw new NotImplementedException();
            }
            public override void PerdeVita()
            {
                throw new NotImplementedException();
            }
        }
        class CCarota : CEsserevivente
        {
            private int mVita;
            public int pVita
            {
                get { return mVita; }
                set { mVita = 100; }
            }
            public override bool Morte()
            {
                if (pVita == 0)
                {
                    return true;
                }
                return false;
            }
            public int c;
            public int r;
            public CCarota(int r, int c)
            {
                this.r = r;
                this.c = c;
            }
        public override void PerdeVita()
            {
                throw new NotImplementedException();
            }
            public override void Muoversi()
            {
            throw new NotImplementedException();
            }

            public override void Mangia()
            {
            throw new NotImplementedException();
            }
            public override void GuadagnaVita()
            {
                throw new NotImplementedException();
            }
        }
}
