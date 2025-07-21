using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SugestedItemsIA {

    [ComVisible(true)]
    [Guid("7D0B5F3A-A52F-4494-A5ED-3E07BC41C2B4")]
    public interface IIAItemList{
        [DispId(-4)]
        IEnumerator GetEnumerator();
        int Count { get; }
        ItemIA this[int index] { get; set; }
        int IndexOf(ItemIA item);
        void Insert(int index, ItemIA item);
        void RemoveAt(int index);
        void Add(ItemIA item);
    }


    [ComVisible(true)]
    [Guid("9048287F-1F07-4A75-B5F7-BF08BD5073EE")]
    public interface IItem {
        string ItemID { get; }
        string Description { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IItem))]
    [ProgId("Item")]
    [Guid("22881F33-9F46-4DD9-9264-F7B5CC64134D")]
    public class ItemIA : IItem {

        public string ItemID { get; set; }
        public string Description { get; set; }


        public ItemIA(string id, string description) {
            ItemID = id;
            Description = description;
        }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IIAItemList))]
    [ProgId("SageCoreAcceptance.APaymentList")]
    [Guid("F938D766-52EA-4393-9412-566F35194671")]
    public class IAItemList : List<ItemIA>, IIAItemList {
        public IAItemList() { }

        public IAItemList(IEnumerable<ItemIA> collection) : base(collection) { }

        IEnumerator IIAItemList.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
