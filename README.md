# PoGoPassCalculator
Small project to try Blazor Web Assembly skills. So I took my (calculator I made in Google Spreadsheets)[https://docs.google.com/spreadsheets/d/1nIKa1sC6rhStHq8cxS3CcWNlQPINuD_GCOGycqA-l6I] and turned it into this web application using Blazor, just to help me understanding how it works.

# What's this?
It is a calculator for checking which raid pass bundle is worthier on Pokémon GO, given a money or PokéCoin amount.

You can check it working here: https://61b6518ee9e47a00082ea46e--pensive-mayer-46d75c.netlify.app/

# Some remarks
- There are two raid pass bundle already configured.
- But you can do your own using the settings page.
- If you refresh the page, everything goes boom - I'm just keeping your inserted bundles in memory
  - because I don't need the overkill of having a small database
  - and I don't want to place it on local storage. (perhaps I shall do it eventually if I see it becomes an issue)
  - because bundles are too stable and not subject to changes lately.
- Found an issue or have a suggestion? I'd be glad to hear more about it. Tell me what happen and if we can reproduce it. Thanks in advance :)
- I don't plan to localize this. I think I can do it later too, along with the local storage implementation. But I don't intend on rushing it.
- You can create your own bundles and check it, just don't refresh the page.
- Those bundles are only counting raid passes, not items. Imagine having to going through all the registration of a new bundle item by item every time a new bundles comes out, when you are just looking up what's the bundle which will give you more raid passes? It would be kind of annoying.

# Final words
Blazor seems to be something. There's a lot to explore, and I am sure I could cover the basics making this tool. It is kind of different if you were an ASP.NET Core/MVC developer, but in general, it is something to keep on watch. I probably wouldn't use it, since I already work with Web for some long, but I found some things quite interesting here, such as routing, injection seems something stronger here, and coding C# is my passion, so I had fun doing this.

As you could in Remarks, I plan to make this better, but, not for now.
