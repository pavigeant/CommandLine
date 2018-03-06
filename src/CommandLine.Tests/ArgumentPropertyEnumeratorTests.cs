//using System;
//using Xunit;

//namespace CommandLine.Tests
//{
//    public class ArgumentPropertyEnumeratorTests
//    {
//        // TODO Replace with ArgumentPropertyEnumerator tests

//        private ArgumentPropertyEnumerator<VerbWithSingleParameterSetting> CreateEnumerator() =>
//                    new ArgumentPropertyEnumerator<VerbWithSingleParameterSetting>(new[] { "test" });

//        [Fact]
//        public void ShouldThrowWhenBeforeEnumeration()
//        {
//            Assert.Throws<InvalidOperationException>(() =>
//            {
//                var enumerator = CreateEnumerator();
//                var a = enumerator.Current;
//            });
//        }

//        [Fact]
//        public void ShouldThrowWhenAfterEnumeration()
//        {
//            Assert.Throws<InvalidOperationException>(() =>
//            {
//                var enumerator = CreateEnumerator();
//                enumerator.MoveNext();
//                enumerator.MoveNext();
//                var a = enumerator.Current;
//            });
//        }

//        [Fact]
//        public void ShouldNotThrowMoveNextAfterEnumeration()
//        {
//            var enumerator = CreateEnumerator();
//            enumerator.MoveNext();
//            enumerator.MoveNext();
//        }
//    }
//}