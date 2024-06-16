using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
//using NUnit.Framework;
using System.Windows.Forms;
using ДП;


namespace TestДП
{
    [TestClass]
    public class UnitTest1
    {
        private PrintedCircuitBoards _pcbForm;
        [TestMethod]
        public void Test_RefreshDataGridData()
        {
            // Arrange
            var dataGridView = GetPrivateField<DataGridView>(_pcbForm, "dataGridView");

            // Act
            _pcbForm.RefreshDataGridData(dataGridView);

            // Assert
            Assert.IsTrue(dataGridView.Rows.Count > 0);
        }

        [TestMethod]
        public void Test_Search()
        {
            // Arrange
            var dataGridView = GetPrivateField<DataGridView>(_pcbForm, "dataGridView");
            var textBoxSearch = GetPrivateField<TextBox>(_pcbForm, "textBoxSearch");
            textBoxSearch.Text = "your_search_query";

            // Act
            _pcbForm.Search(dataGridView);

            // Assert
            Assert.IsTrue(dataGridView.Rows.Count > 0);
        }

        // Метод для получения доступа к закрытым полям с помощью рефлексии
        private T GetPrivateField<T>(object obj, string fieldName)
        {
            var fieldInfo = typeof(PrintedCircuitBoards).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            return (T)fieldInfo.GetValue(obj);
        }
    }
}

