namespace PGSysIntegrator.Infrastructure.Helpers
{
    class MaximoSystemDiscoveryProcessor
    {

       
        // ================================================================
        // NOT Implemented - Automatic System and Location Root Discovery
        // ================================================================
        //ToDo: Get a list of systems for the `MXAPILOCSYSTEM`object structure
        //  GET /os/mxapilocsystem?oslc.select=systemid,description - The returned set will be a list of all systems 
        //ToDo: Collection Create: Map that structure to MaximoClientSystemsHierarchy collection.
        //ToDo: Save MaximoClientSystemsHeirchy collection to MaximoClientSystemsHeirchy Table data to ReferenceDb
        //ToDo: Collection Create: Find the roots of each system listed in the MaximoClientSystemsHierarchy collection and save them to MaximoClientSystemRoots collection
        //  GET /os/mxapilocsystem/{systemid}/topleveloc.mxapioperloc?oslc.select=systemid,description
        //ToDo: Save MaximoClientSystemRoots collection to MaximoClientSystemRoots Table in ReferenceDb with foreign keys to MaximoClientSystemsHierarchy Table
        //ToDo: For each system root in the MaximoClientSystemRoots collection, drill down using the href of the system record.
        // GET /os/mxapioperloc/{id}/syschildren.mxapioperloc?ctx=systemid=<systemid> -->  The returned set will be the CoreRootLocations of the given system
        //   NOTE: The above query parameter:   ctx  - Is used with the value of:  systemid=<systemid>  for the system that is being drilled down into.
        //   Important: A location can belong to multiple systems and hence multiple hierarchies.
        // ToDo: Collection Create: Map that structure to ClientSystemsCoreRootLocations collection
        // ToDo: Save ClientSystemsCoreRootLocations collection to ClientSystemsCoreRootLocations Table in ReferenceDb with foreign keys to MaximoClientSystemRoots Table
        // ToDo: Save these core locations in the 
        // ================================================================
        // =======================================================================
        // Reference Document: Maximo_REST_API_Guide.pdf - 19.1. Location hierarchy
        // ==========================================================================
        // 
    }
}
