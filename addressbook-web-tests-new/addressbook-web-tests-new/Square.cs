﻿using System;

namespace addressbook_web_tests_new
{
    class Square:Figure
    {
        private int size;
       
        public Square(int size)
        {
            this.size = size;

    }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
       
    }
}
