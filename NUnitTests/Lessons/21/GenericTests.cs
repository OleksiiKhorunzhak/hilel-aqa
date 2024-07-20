namespace Lesson21
{
    [TestFixture]
    public class GenericTests
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        [Test]
        public void Swap_ShouldSwapIntValues()
        {
            int x = 1, y = 2;
            Swap(ref x, ref y);
            Assert.Multiple(() =>
            {
                Assert.That(x, Is.EqualTo(2));
                Assert.That(y, Is.EqualTo(1));
            });
        }

        [Test]
        public void Swap_ShouldSwapStringValues()
        {
            string a = "first", b = "second";
            Swap(ref a, ref b);
            Assert.Multiple(() =>
            {
                Assert.That(a, Is.EqualTo("second"));
                Assert.That(b, Is.EqualTo("first"));
            });
        }

        [Test]
        public void Container_ShouldStoreAndDisposeItem()
        {
            var resource = new DisposableResource();
            var container = new Container<DisposableResource>(resource);

            Assert.That(resource.IsDisposed, Is.False);
            container.DisposeItem();
            Assert.That(resource.IsDisposed, Is.True);
        }
    }

    public class Container<T> where T : IDisposable
    {
        public T Item { get; private set; }

        public Container(T item)
        {
            Item = item;
        }

        public void DisposeItem()
        {
            Item.Dispose();
        }
    }

    public class DisposableResource : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}
