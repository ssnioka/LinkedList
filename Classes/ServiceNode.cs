namespace _2LABORAS.Classes
{
    public sealed class ServiceNode
    {
        private Service service;

        public ServiceNode next { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public ServiceNode() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="servicenode"></param>
        public ServiceNode(Service service, ServiceNode servicenode)
        {
            this.service = service;
            next = servicenode;
        }

        /// <summary>
        /// to get the service
        /// </summary>
        /// <returns></returns>
        public Service Get()
        {
            return service;
        }
    }
}
