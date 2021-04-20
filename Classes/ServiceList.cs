namespace _2LABORAS.Classes
{ 
    public sealed class ServiceList
    {
        private ServiceNode Head;
        private ServiceNode Tail;
        private ServiceNode Temp;


        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceList()
        {
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// temp node to the head
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
            Temp = Tail;
        }

        /// <summary>
        /// to check if the temp node exists
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return (Temp != null);
        }

        /// <summary>
        /// temp node to next
        /// </summary>
        public void Next()
        {
            Temp = Temp.next;

        }
        /// <summary>
        /// getting the node
        /// </summary>
        /// <returns></returns>
        public Service Get()
        {
            return Temp.Get();
        }

        /// <summary>
        /// method to put new data
        /// </summary>
        /// <param name="service"></param>
        public void PutData(Service service)
        {
            var temp = new ServiceNode(service, null);
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
    }
}
