using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RubiksTangle.Application.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RubiksTangle.Web.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly IMediator mediatR;
        public GameController(IMediator mediatR)
        {
            this.mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }

        [HttpPost]
        public async Task<bool> CardShuffle()
        {
            return await this.mediatR.Send(new CardSuffle());
        }

        [HttpGet]
        public async Task<IEnumerable<CardViewModel>> GetPictures()
        {
            
            return await this.mediatR.Send(new GetCards());
        }

        [HttpGet]
        public async Task<IEnumerable<SolutionStepModel>> GetSolutionSteps()
        {
            return await this.mediatR.Send(new GetSolutionSteps());
        }
    }
}
