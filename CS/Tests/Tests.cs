using System.Linq;
using System.Threading;
using System.Windows.Threading;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.PropertyGrid;
using DevExpress.Xpf.Reports.UserDesigner.PropertyGrid;
using NUnit.Framework;

namespace CustomizePropertyGridCategories
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class Tests {
        [Test]
        public void CustomCategoryIsApplied() {
            var window = new MainWindow();
            window.Show();
            DispatcherHelper.DoEvents(DispatcherPriority.ApplicationIdle, 7);
            DispatcherHelper.UpdateLayoutAndDoEvents(window, DispatcherPriority.ApplicationIdle);
            var propertyGrid = LayoutTreeHelper.GetVisualChildren(window).OfType<ReportDesignerPropertyGrid>().Single();
            var propertyGridView = propertyGrid.View;
            var categoriesSource = propertyGridView.CategoriesSource.Cast<RowData>().ToList();
            
            Assert.That(categoriesSource.Count, Is.EqualTo(7));
            var myTabCategory = categoriesSource[5];
            Assert.That(myTabCategory.IsCategory);
            Assert.That(myTabCategory.Header, Is.EqualTo("My tab"));
        }
    }
}
