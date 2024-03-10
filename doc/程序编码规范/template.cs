//**********************************************************************
// Script Name          : template.cs
// Author Name          : 张辉平
// Create Time          : 2023/10/17
// Last Modified Time   : 2023/10/17
// Description          : 此脚本为演示编码规范的示例脚本
//**********************************************************************

using System;

namespace TeaProject
{
    /// <summary>
    /// 测试类。此项用于演示class的XML注释
    /// </summary>
    class TestClass
    {

        #region Public or protected fields and properties

        /// <summary>
        /// 测试属性。此项用于演示Property的XML注释
        /// </summary>
        /// <value>此值无意义</value>
        public int TestProperty
        {
            get
            {
                return m_Field;
            }
            set
            {
                m_Field = value;
            }
        }

        #endregion

        #region Private fields and properties

        private int m_Field;

        #endregion

        #region Unity Callback

        private void Start()
        {

        }

        private void Update()
        {

        }

        #endregion

        #region Public or protected method

        /// <summary>
        /// 测试函数。此项用于演示Method的XML注释
        /// </summary>
        /// <param name="a">参数注释</param>
        /// <returns>返回值注释</returns>
        public int TestMethod(int a)
        {
            return a;
        }

        #endregion

        #region Private method

        private void int TestPriMethod()
        {

        }

        protected void void TestProMethod()
        {

        }

        #endregion

    }
}

