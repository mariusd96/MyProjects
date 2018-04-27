using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.repository;
using Opera.model;

namespace Opera.Tests
{
    [TestFixture]
    public class TestBench
    {
        private UserRepository _userRepo;
        private SpectacolRepository _spectacolRepo;

        public TestBench()
        {
            _userRepo = new UserRepository();
            _spectacolRepo = new SpectacolRepository();
        }

        [Test]
        public void test1()
        {
            //insert casier
            Casier c = new Casier();
            c.Nume = "Popescu Ana";
            c.Username = "ana.popescu";
            c.Password = "vals";

            _userRepo.operatiiCasier(c, 0);//insert
            c.Password = "vals";//metoda de mai sus schimba datele

            List<Casier> lc = _userRepo.getCasieri();
            Casier ctest = lc.Where(x => x.Nume == c.Nume).SingleOrDefault();
            
            Assert.IsTrue(ctest.ToString() == c.ToString());
        }

        [Test]
        public void test2()
        {
            //update casier
            Casier c = new Casier();
            c.Nume = "Ionescu Ana";
            c.Username = "ana.popescu";
            c.Password = "vals";

            _userRepo.operatiiCasier(c, 1);//update
            c.Password = "vals";//metoda de mai sus schimba datele

            List<Casier> lc = _userRepo.getCasieri();
            Casier ctest = lc.Where(x => x.Nume == c.Nume).SingleOrDefault();

            Assert.IsTrue(ctest.ToString() == c.ToString());
        }

        [Test]
        public void test3()
        {
            //delete casier
            Casier c = new Casier();
            c.Nume = "Ionescu Ana";
            c.Username = "ana.popescu";
            c.Password = "vals";

            _userRepo.operatiiCasier(c, 2);//delete

            List<Casier> lc = _userRepo.getCasieri();
            Casier ctest = lc.Where(x => x.Nume == c.Nume).SingleOrDefault();

            Assert.IsTrue(ctest == null);
        }

        [Test]
        public void test4()
        {
            //insert spectacol
            Spectacol s = new Spectacol();
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "2018-12-27 18:00:00";
            s.NumarBilete = 75;

            _spectacolRepo.operatiiSpectacol(s, 0);//insert

            List<Spectacol> ls = _spectacolRepo.getSpectacole();
            Spectacol stest = ls.Where(x => x.Titlu == s.Titlu).SingleOrDefault();
            s.IdSpectacol = 6;
            s.DataPremiere = "27.12.2018 18:00:00";

            //System.Windows.MessageBox.Show(stest.ToString());
            //System.Windows.MessageBox.Show(s.ToString());

            Assert.IsTrue(stest.ToString() == s.ToString());
        }

        [Test]
        public void test5()
        {
            //update spectacol
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "2018-12-27 18:00:00";
            s.NumarBilete = 125;//am schimbat numarul biletelor

            _spectacolRepo.operatiiSpectacol(s, 1);//update

            List<Spectacol> ls = _spectacolRepo.getSpectacole();
            Spectacol stest = ls.Where(x => x.Titlu == s.Titlu).SingleOrDefault();
            s.DataPremiere = "27.12.2018 18:00:00";

            Assert.IsTrue(stest.ToString() == s.ToString());
        }

        [Test]
        public void test6()
        {
            //insert actor
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "27.12.2018 18:00:00";
            s.NumarBilete = 125;

            DistributieOp d_op = new DistributieOp();
            d_op.IdSpectacol = 6;
            d_op.NumeActor = "Teodora Gheorghiu";
            d_op.RolActor = "MImi";

            _spectacolRepo.operatiiActorOp(d_op, 0);//insert

            List<DistributieOp> ld_op = _spectacolRepo.getActoriOp(s);
            DistributieOp dtest = ld_op.Where(x => x.NumeActor == d_op.NumeActor).SingleOrDefault();

            Assert.IsTrue(d_op.IdSpectacol == dtest.IdSpectacol && d_op.NumeActor == dtest.NumeActor && d_op.RolActor == dtest.RolActor);
        }

        [Test]
        public void test7()
        {
            //update actor
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "27.12.2018 18:00:00";
            s.NumarBilete = 125;

            DistributieOp d_op = new DistributieOp();
            d_op.IdActorOp = 44;
            d_op.IdSpectacol = 6;
            d_op.NumeActor = "Teodora Gheorghiu";
            d_op.RolActor = "Mimi";//la testul precedent a fost MImi

            _spectacolRepo.operatiiActorOp(d_op, 1);//update

            List<DistributieOp> ld_op = _spectacolRepo.getActoriOp(s);
            DistributieOp dtest = ld_op.Where(x => x.NumeActor == d_op.NumeActor).SingleOrDefault();

            Assert.IsTrue(d_op.IdSpectacol == dtest.IdSpectacol && d_op.NumeActor == dtest.NumeActor && d_op.RolActor == dtest.RolActor);
        }

        [Test]
        public void test8()
        {
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "2018-12-27 18:00:00";
            s.NumarBilete = 125;

            //delete actor
            DistributieOp d_op = new DistributieOp();
            d_op.IdActorOp = 44;
            d_op.IdSpectacol = 6;
            d_op.NumeActor = "Teodora Gheorghiu";
            d_op.RolActor = "Mimi";

            _spectacolRepo.operatiiActorOp(d_op, 2);//delete

            List<DistributieOp> ld_op = _spectacolRepo.getActoriOp(s);
            DistributieOp dtest = ld_op.Where(x => x.NumeActor == d_op.NumeActor).SingleOrDefault();
            //System.Windows.MessageBox.Show(dtest.ToString());
            Assert.IsTrue(dtest == null);
        }

        [Test]
        public void test9()
        {
            //insert bilet
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "2018-12-27 18:00:00";
            s.NumarBilete = 125;//am schimbat numarul biletelor

            Bilet b = new Bilet();
            b.IdSpectacol = 6;
            b.Rand = b.Coloana = 1;

            _spectacolRepo.insertBilet(b);

            List<Bilet> lb = _spectacolRepo.getBileteBySpectacol(s);
            Bilet btest = lb.Where(x => x.IdBilet == 28).SingleOrDefault();//28 = idBilet urmator in BD
            b.IdBilet = 28;

            Assert.IsTrue(btest.ToString() == b.ToString());
        }

        [Test]
        public void test10()
        {
            //delete spectacol
            Spectacol s = new Spectacol();
            s.IdSpectacol = 6;
            s.Titlu = "Boema";
            s.Regia = "Ina Hudea";
            s.Gen = "Operă";
            s.DataPremiere = "2018-12-27 18:00:00";
            s.NumarBilete = 125;//am schimbat numarul biletelor

            _spectacolRepo.operatiiSpectacol(s, 2);//delete

            List<Spectacol> ls = _spectacolRepo.getSpectacole();
            Spectacol stest = ls.Where(x => x.Titlu == s.Titlu).SingleOrDefault();

            Assert.IsTrue(stest == null);
        }
    }
}
