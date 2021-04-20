namespace _2LABORAS.Classes
{
    public sealed class ResidentNode
    {
        private Resident resident;
        public ResidentNode next { get; set; }

        /// <summary>
        /// empty constructor
        /// </summary>
        public ResidentNode() { }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="resident"></param>
        public ResidentNode(Resident resident)
        {
            this.resident = resident;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="resident"></param>
        /// <param name="residentnode"></param>
        public ResidentNode(Resident resident, ResidentNode residentnode)
        {
            this.resident = resident;
            next = residentnode;
        }

        /// <summary>
        /// method to get the resident
        /// </summary>
        /// <returns></returns>
        public Resident Get()
        {
            return resident;
        }

        /// <summary>
        /// method used to set the collectionist
        /// </summary>
        /// <param name="resident"></param>
        public void Set(Resident resident)
        {
            this.resident = resident;
        }

        /// <summary>
        /// comparing method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ResidentNode other)
        {
            if (resident.Surname.CompareTo(other.resident.Surname) == 0 && resident.Address.CompareTo(other.resident.Address) == 0)
            {             
                return resident.Name.CompareTo(other.resident.Name);
            }
            else
            {
                return resident.Surname.CompareTo(other.resident.Surname);
            }
        }
    }
}
