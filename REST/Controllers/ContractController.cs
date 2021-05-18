using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend_RentHouse_Khalifa_Sami.Model.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;
using TFE_Khalifa_Sami_2021.REST.DTO;
using TFE_Khalifa_Sami_2021.REST.Repositories;

namespace TFE_Khalifa_Sami_2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContractController: Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractController(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProperties()
        {
            IEnumerable<Contract> contracts = _contractRepository.GetProperties();
            IEnumerable<ContractDto> contractsDto = _mapper.Map<IEnumerable<ContractDto>>(contracts);
            return Ok(contractsDto);
        }
        
        [HttpGet("getById/{id}")]
        public IActionResult GetPropertyById(int id)
        {
            Contract contract = _contractRepository.GetPropertyById(id);
            ContractDto contractDto = _mapper.Map<ContractDto>(contract);
            return Ok(contractDto);
        }
        
        [HttpGet("doc/{id}/{type}")]
        public FileStreamResult GetDocumentByIdType(int id, string type)
        {
            Contract contract = _contractRepository.GetPropertyById(id);

            Enum.TryParse(type, out TypeContract tp);
            Document doc = new Document(contract,tp);
            string filePath = doc.GenerateDocument();
            string fileName =  doc.GetFileName();
            const string mimeType ="application/vnd.ms-word"; 

            return new FileStreamResult(System.IO.File.OpenRead(filePath), mimeType)
            {
                FileDownloadName = fileName
            };
        }
        
        [HttpPost]
        public IActionResult PostProperty(ContractDto contractDto)
        {
            Contract contract = _mapper.Map<Contract>(contractDto);
            _contractRepository.PostProperty(contract);
            return Ok(contract);
        }
        
        [HttpPut]
        public IActionResult UpdateProperty(ContractDto contractDto)
        {
            Contract contract = _mapper.Map<Contract>(contractDto);
            _contractRepository.UpdateProperty(contract);
            return Ok(contract);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _contractRepository.DeleteProperty(id);
            return Ok($"{id} Removed ! ");
        }
    }
}