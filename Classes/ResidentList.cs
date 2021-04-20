namespace _2LABORAS.Classes
{
    public sealed class ResidentList
    {
        private ResidentNode Head;
        private ResidentNode Temp;
        private ResidentNode Tail;

        /// <summary>
        /// Constructor to create linkedlist
        /// </summary>
        public ResidentList()
        {
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// method to set temp node to the head
        /// </summary>
        public void Beginning()
        {
            Temp = Head;
        }
        /// <summary>
        /// method to set temp node to the tail
        /// </summary>
        public void Ending()
        {
            Head = Tail;
        }

        /// <summary>
        /// method to check if the node exists
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return (Temp != null);
        }

        /// <summary>
        /// method to set temp node to the next node
        /// </summary>
        public void Next()
        {
            Temp = Temp.next;
        }
        /// <summary>
        /// method to remove the node in the list
        /// </summary>
        /// <param name="resident"></param>
        public void Remove(ResidentNode resident)
        {
            ResidentNode temp = Head;
            ResidentNode prev = null;

            if (temp != null && temp.Get() == resident.Get())
            {
                Head = temp.next;
                return;
            }

            while(temp!= null && temp.Get() != resident.Get())
            {
                prev = temp;
                temp = temp.next;
            }

            if (temp == null)
                return;

            prev.next = temp.next;
        }
        /// <summary>
        /// method to get temp resident
        /// </summary>
        /// <returns></returns>
        public Resident Get()
        {
            return Temp.Get();
        }
        /// <summary>
        /// method to get the temp node
        /// </summary>
        /// <returns></returns>
        public ResidentNode GetNode()
        {
            return Temp;
        }

        /// <summary>
        /// method to put data
        /// </summary>
        /// <param name="resident"></param>
        public void PutData(Resident resident)
        {
            var temp = new ResidentNode(resident, null);
            if (Head != null)
            {
                Tail.next = temp;
                Tail = temp;
            }
            else
            {
                Head = temp;
                Tail = temp;
            }

        }
        /// <summary>
        /// method used to get count of the linked list
        /// </summary>
        /// <returns></returns>
        public int getCount()
        {
            ResidentNode temp = Head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
       
        /// <summary>
        /// method for sorting
        /// </summary>
        public void Sort()
        {
            if (Head.next == Tail) 
            {
                return;
            }
            bool done = true;
            while(done)
            {
                done = false;
                var headn = Head.next;
                while (headn.next.next != null)
                {
                    if(headn.CompareTo(headn.next)<0)
                    {
                        Resident ab = headn.Get();
                        headn.Set(headn.next.Get());
                        headn.next.Set(ab);
                        done = true;
                    }
                    headn = headn.next;
                }
            }
        }
        

    }
}
