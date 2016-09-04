
build:
	mcs Program.cs -out:adkeyboard

start:
	mono ./adkeyboard

clean:
	rm adkeyboard

.PHONY: build clean
