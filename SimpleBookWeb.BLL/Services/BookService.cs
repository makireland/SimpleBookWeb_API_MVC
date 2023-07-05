using SimpleBookWeb.BLL.InterfaceServices;
using SimpleBookWeb.Domain.Dtos;
using SimpleBookWeb.Domain.Models;
using SimpleBookWeb.Infra.InterfacesRepo;

namespace SimpleBookWeb.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Add(BookDto bookDto)
        {
            var bookEntity = ConvertToBookEntity(bookDto);

            bookEntity.Registration = DateTime.Now;
;            await _bookRepository.Add(bookEntity);

            await _bookRepository.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var request = await _bookRepository.GetAll();
            return ConvertEntityListToDtoList(request);
        }

        private IEnumerable<BookDto> ConvertEntityListToDtoList(IEnumerable<Book> request)
        {
            var listDto = new List<BookDto>();

            foreach (var book in request)
            {
                listDto.Add(ConvertToBookDto(book));
            }

            return listDto;
        }

        public async Task<BookDto> GetById(int id)
        {
            var book = await _bookRepository.GetById(id);

            return ConvertToBookDto(book);
        }

        public async Task<BookDto> Update(BookDto bookDto)
        {
            var bookEntity = ConvertToBookEntity(bookDto);

            _bookRepository.Update(bookEntity);

            await _bookRepository.SaveChangesAsync();

            return bookDto;
        }


        public async Task<BookDto> Delete(BookDto bookDto)
        {
            var bookEntity = ConvertToBookEntity(bookDto);

            _bookRepository.Delete(bookEntity);

            await _bookRepository.SaveChangesAsync();

            return bookDto;
        }

        public Book ConvertToBookEntity(BookDto bookDto)
        {
            var bookEntity = new Book
            {
                Id = bookDto.Id,
                CategoryId = bookDto.CategoryId,
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Registration = bookDto.Registration,
            };

            return bookEntity;
        }

        public BookDto ConvertToBookDto(Book book)
        {
            var bookDto = new BookDto
            {
                Id = book.Id,
                CategoryId= book.CategoryId,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                Registration = book.Registration,
                CategoryName = book.Category?.Name
            };

            return bookDto;
        }
    }
}
