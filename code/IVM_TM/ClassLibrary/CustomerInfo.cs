using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace EntityClass
{
    class CustomerInfo
    {
        private static ArrayList CustomerList= new ArrayList();//创建储存客户信息的ArrayList
        private String id;//表示客户ID的字段
        private String name;//表示客户姓名字段
        private String address;//表示客户地址字段
        private CustomerInfo(String myid, String myname, String myaddress)
        {
            //有参数构造函数，对私有字段初始化
            id = myid;
            name = myname;
            address = myaddress;
    }
        public String ID//表示客户ID的属性
        {
            set { id = value; }
            get { return id; }
        }
        public String Name //表示客户姓名的属性
        {
            get { return name; }
            set { name = value; }
        }
        public String Address//表示客户地址的属性
        {
            get { return address; }
            set { address = value; }
        }
        public static void AddCustomer(CustomerInfo aCustomerInfo)//添加客户信息的方法
        {
            CustomerList.Add(aCustomerInfo);//添加一个客户信息到ArrayList中
        }
        public static void Delete (CustomerInfo oo)
        {
            int i = CustomerList.IndexOf(oo);
            if (i < 0)
                Console.WriteLine("No!");
            else
                CustomerList.RemoveAt(i);
        }
        public static void Show ()
        {
            foreach (CustomerInfo s in CustomerList)
                Console.WriteLine(s.ID + ", "+s.Name +", "+s.Address);
        }
}
