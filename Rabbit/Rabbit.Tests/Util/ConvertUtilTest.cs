using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabbit.Util;
using Rabbit.Util.Extensions;

namespace Rabbit.Tests.Util {
    [TestClass]
    public class ConvertUtilTest {
        [TestMethod]
        public void ConvertTest() {

            Assert.AreEqual(ConvertUtil.To<int>("1"), 1);

            Assert.AreEqual("1".Convert<int>(), 1);

            var obj = new object();

            SetNull(ref obj);

            Assert.AreEqual(obj.Convert<int>(), default(int));

            Assert.AreEqual(obj.Convert<int?>(), null);

            Assert.AreEqual(ConvertUtil.To<int>("1a"), default(int));

            Assert.AreEqual(ConvertUtil.To<int?>("1a"), null);

            Assert.AreEqual(ConvertUtil.To<bool>("false"), false);

            Assert.AreEqual(ConvertUtil.To<bool>("tRue"), true);
          
            Assert.AreEqual(ConvertUtil.To<bool>("tRue1"), default(bool));

            Assert.AreEqual(ConvertUtil.To<bool?>("tRue1"), null);

            Assert.AreEqual(ConvertUtil.To<DateTime?>("2015-1-1"), DateTime.Parse("2015-1-1"));

            Assert.AreEqual(ConvertUtil.To<DateTime?>("aaa"), null);

            Assert.AreEqual(ConvertUtil.To(ConvertEnum.A, 0), 1);

            Assert.AreEqual(ConvertUtil.To(1, ConvertEnum.A), ConvertEnum.A);

            Assert.AreEqual(ConvertUtil.To<ConvertEnum?>(1).Value, ConvertEnum.A);

            Assert.AreEqual(ConvertUtil.To<ConvertEnum?>(2).Value, ConvertEnum.B);

            Assert.AreEqual(ConvertUtil.To<ConvertEnum?>(4), null);

            Assert.AreEqual(ConvertUtil.To<ConvertEnum?>("a"), null);

            Assert.AreEqual(ConvertUtil.To<ConvertEnum?>("A").Value, ConvertEnum.A);


        }

        private void SetNull(ref object obj) {
            obj = null;
        }

        private enum ConvertEnum {
            A = 1,
            B = 2,
            C = 3
        }
    }
}
