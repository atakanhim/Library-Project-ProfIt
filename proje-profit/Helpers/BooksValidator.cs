
using FluentValidation;
using proje_profit.Models;

namespace proje_profit.Helpers
{
    public class BooksValidator :AbstractValidator<BooksViewModel>
    {
        public BooksValidator()
        {
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("bos olamaz")
                .MinimumLength(11).WithMessage("11 karakter olmalı en az");
            RuleFor(x => x.BookTitle).NotEmpty().WithMessage("book title bos olamaz");
            RuleFor(x => x.BookAuthor).NotEmpty().WithMessage("book title bos olamaz");
        }
    }
}
