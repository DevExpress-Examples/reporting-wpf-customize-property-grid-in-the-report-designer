Imports System.Linq
Imports System.Threading
Imports System.Windows.Threading
Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PropertyGrid
Imports DevExpress.Xpf.Reports.UserDesigner.PropertyGrid
Imports NUnit.Framework

Namespace CustomizePropertyGridCategories
	<TestFixture, Apartment(ApartmentState.STA)>
	Public Class Tests
		<Test>
		Public Sub CustomCategoryIsApplied()
			Dim window = New MainWindow()
			window.Show()
			DispatcherHelper.DoEvents(DispatcherPriority.ApplicationIdle, 7)
			DispatcherHelper.UpdateLayoutAndDoEvents(window, DispatcherPriority.ApplicationIdle)
			Dim propertyGrid = LayoutTreeHelper.GetVisualChildren(window).OfType(Of ReportDesignerPropertyGrid)().Single()
			Dim propertyGridView = propertyGrid.View
			Dim categoriesSource = propertyGridView.CategoriesSource.Cast(Of RowData)().ToList()

			Assert.That(categoriesSource.Count, [Is].EqualTo(7))
			Dim myTabCategory = categoriesSource(5)
			Assert.That(myTabCategory.IsCategory)
			Assert.That(myTabCategory.Header, [Is].EqualTo("My tab"))
		End Sub
	End Class
End Namespace
