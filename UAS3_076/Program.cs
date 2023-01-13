using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS3_076
{
    class Node
    {
        public string idbrg;
        public int jnsbrg;
        public string namabrg;
        public string hrgbrg;

        public Node next;
        public Node prev;
    }

    class Toko
    {
        Node START;

        public void add()
        {
            string id;
            int jns;
            string nama;
            string hrg;
            Console.Write("\nMasukkan ID Barang: ");
            id = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Barang: ");
            jns = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Barang: ");
            nama = Console.ReadLine();
            Console.WriteLine("\nMasukkan Harga Barang: ");
            hrg = Console.ReadLine();
            Node newNode = new Node();
            newNode.idbrg = id;
            newNode.jnsbrg = jns;
            newNode.namabrg = nama;
            newNode.hrgbrg = hrg;

            if (START == null || jns <= START.jnsbrg)
            {
                if ((START != null) && (jns == START.jnsbrg))
                {
                    Console.WriteLine("\nData Duplikat");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                 current != null && jns >= current.jnsbrg;
                 previous = current, current = current.next)
            {
                if (jns == current.jnsbrg)
                {
                    Console.WriteLine("\nData Duplikat");
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(int jenis, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null &&
                jenis != current.jnsbrg)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }

        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nDaftar Kosong");
            else
            {
                Console.WriteLine("\nDaftar " + "Jenis Barang:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.jnsbrg + currentNode.namabrg + "\n");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Toko obj = new Toko();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan Data Barang");
                    Console.WriteLine("2. Menampilkan Data Barang");
                    Console.WriteLine("3. Mencari Data Barang");
                    Console.WriteLine("4. Exit\n");
                    Console.WriteLine("Masukkan Pilihan (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.add();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nDaftar Kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Jenis Barang Yang Akan DiCari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData Tidak Ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Berhasil Ditemukan");
                                    Console.WriteLine("\nJenis Barang: " + curr.jnsbrg);
                                    Console.WriteLine("\nID Barang: " + curr.idbrg);
                                    Console.WriteLine("\nNama: " + curr.namabrg);
                                    Console.WriteLine("\nHarga Barang: " + curr.hrgbrg);
                                }
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Pilihan Tidak Tersedia");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Periksa Data Yang Dimasukkan");
                }
            }
        }
    }
}

/*
2. Algoritma single linked list, karena bisa digunakan untuk mengurutkan data
3. Insertion and deletion in a linked list is fast as compared to array.
   accessing elements is faster in arrays as compared to linked lists.
4. rear, front
5. 
    a. (41,74) (16,53) (46,55) (63,70) (62,64)
    b. Preorder (60, 41, 16, 25, 53, 46, 42, 55, 74, 65, 63, 62, 70, 64)
*/