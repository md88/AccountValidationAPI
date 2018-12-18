using AutoMapper;
using Moq;
using NUnit.Framework;
using SortingCodeAccountValidationAPI.Controllers;
using SortingCodeAccountValidationAPI.Domain.Services;
using SortingCodeAccountValidationAPI.ViewModels;
using System;

namespace SortingCodeAccountValidationAPI.Tests
{
    public class ValidationControllerTests
    {
        private ValidationController sut;

        private Mock<IValidationService> mockValidationService;

        private Mock<IMapper> mockMapper;

        [SetUp]
        public void SetUp()
        {
            this.mockValidationService = new Mock<IValidationService>();
            this.mockMapper = new Mock<IMapper>();

            sut = new ValidationController(this.mockValidationService.Object, this.mockMapper.Object);
        }

        [Test]
        public void When_model_is_invalid_then_return_bad_request()
        {
            var model = new SortingCodeAccountValidationViewModel();

            this.sut.TryValidateModel(null);
            this.sut.Post(model);
        }
    }
}
