using FluentAssertions;
using NUnit.Framework;
using SampleDI;
using System;

namespace SimpleDITests
{
    [TestFixture]
    public class SimpleInjectTest
    {
        SimpleInject _simpleInject;

        [SetUp]
        public void InitBindTest()
        {
            _simpleInject = new SimpleInject();                       
        }

        [Test]
        public void BindToSelfGenericTest()
        {
            _simpleInject.Bind<StandartEngine>().ToSelf();
            _simpleInject.Instances.TryGetValue(typeof(StandartEngine), out Type type);
            _simpleInject.Instances.Count.Should().Be(1);
            type.Should().Subject.FullName.Contains("StandartEngine");
        }

        [Test]
        public void BindToSelfGenericExceptionTest()
        {
            Action action = () =>_simpleInject.Bind<IEngine>().ToSelf();
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void BindGenericTest()
        {
            _simpleInject.Bind<IEngine>().To<StandartEngine>();
            _simpleInject.Bind<IEngine>().To<StandartEngine>();            
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type);
            _simpleInject.Instances.Count.Should().Be(1);
            type.Should().Subject.FullName.Contains("StandartEngine");
        }

        [Test]
        public void UnBindGenericTest()
        {
            _simpleInject.Bind<IEngine>().To<StandartEngine>();            
            _simpleInject.UnBind<IEngine>();
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type).Should().BeFalse();
            type.Should().BeNull();
        }

        [Test]
        public void BindNotGeneric1Test()
        {
            _simpleInject.Bind<IEngine>().To(typeof(StandartEngine));
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type);
            type.Should().Subject.FullName.Contains("StandartEngine");
        }

        [Test]
        public void BindNotGeneric2Test()
        {
            _simpleInject.Bind(typeof(IEngine)).To(typeof(StandartEngine));
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type);
            type.Should().Subject.FullName.Contains("StandartEngine");
        }

        [Test]
        public void BindNotGenericExceptionTest()
        {
            Action action = () => _simpleInject.Bind<IEngine>().To(typeof(Car));
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void BindNotGeneric2ExceptionTest()
        {
            Action action = () => _simpleInject.Bind(typeof(IEngine)).To(typeof(Car));
            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void UnBindNotGenericTest()
        {
            _simpleInject.Bind<IEngine>().To(typeof(StandartEngine));
            _simpleInject.UnBind(typeof(IEngine));
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type).Should().BeFalse();
            type.Should().BeNull();
        }

        [Test]
        public void UnBindNotGeneric2Test()
        {
            _simpleInject.Bind(typeof(IEngine)).To(typeof(StandartEngine));
            _simpleInject.UnBind(typeof(IEngine));
            _simpleInject.Instances.TryGetValue(typeof(IEngine), out Type type).Should().BeFalse();
            type.Should().BeNull();
        }

        [Test]
        public void ResolveGenericTest()
        {
            _simpleInject.Bind<IEngine>().To<StandartEngine>();
            _simpleInject.Bind<StandartEngine>().To<StandartEngine>();
            var type= _simpleInject.Resolve<IEngine>();
            type.Should().BeOfType<StandartEngine>();
        }
    }
}
