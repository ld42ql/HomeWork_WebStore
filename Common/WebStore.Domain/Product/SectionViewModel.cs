using System.Collections.Generic;


namespace WebStore.Domain.Product
{
    /// <summary>
    /// Представления секций
    /// </summary>
    public class SectionViewModel
    {
        public SectionViewModel()
        {
            this.ChildSections = new List<SectionViewModel>();
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Дочерняя секция
        /// </summary>
        public List<SectionViewModel> ChildSections { get; set; }

        /// <summary>
        /// Родительская секция
        /// </summary>
        public SectionViewModel ParentSection { get; set; }
    }
}
