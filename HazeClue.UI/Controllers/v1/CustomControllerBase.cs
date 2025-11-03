using Microsoft.AspNetCore.Mvc;

namespace HazeClue.UI.Controllers.v1
{
    /// <summary>
    /// Represents the base API controller for version 1 endpoints.
    /// Provides common functionality and configuration for all API controllers in version 1.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {

    }
}
