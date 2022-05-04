using NUnit.Framework;
using MyView.Model;
using System;

namespace MyView.TESTE
{
    public class TesteJogo
    {

        DB_JogosContext db;
        
        
        [SetUp]
        public void Setup()
        {
            db = new DB_JogosContext();
        }

        [Test]
        public void Incluir()
        {
            
            
                DboTbjogos oJog = new DboTbjogos();
                oJog.Jogo = "Inclusão:" + DateTime.Now.ToString("HH:mm:ss");
                db.DboTbjogos.Add(oJog);
                db.SaveChanges();
                Assert.Pass();
            


            Assert.Pass();
        }

        [Test]
        public void Alterar()
        {
            DboTbjogos ?oJog = db.DboTbjogos.Find(1);
            if (oJog != null)
            {
                oJog.Jogo = "Alteração:" + DateTime.Now.ToString("HH:mm:ss");
                db.Entry(oJog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                Assert.Pass();
            }
            else
            {

                Assert.Fail("Não encontrou um Jogo para alterar.");
            }

            Assert.Pass();
        }
    }
}